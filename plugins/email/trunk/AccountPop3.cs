/*
The contents of this file are subject to the Mozilla Public License
Version 1.1 (the "License"); you may not use this file except in
compliance with the License. You may obtain a copy of the License at
http://www.mozilla.org/MPL/

Software distributed under the License is distributed on an "AS IS"
basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
License for the specific language governing rights and limitations
under the License.

The Original Code is om3 controller library, UI and various plugins.

The Initial Developer of the Original Code is Harald Röxeisen.
Portions created by the initial developer are Copyright (C) 2007
the initial developer. All Rights Reserved.

Contributor(s): Harald Röxeisen.
*/


using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;


namespace EmailNotifierPlugin
{

  internal class AccountPop3 : AccountBase
  {

    public List<string> _KnownMessages;
    private int _Count;
    private int _Size;
    private bool _Secure;


    public AccountPop3()
    {
      _KnownMessages = new List<string>();
    }


    public bool Secure
    {
      get { return _Secure; }
      set { _Secure = value; }
    }


    public override List<Message> GetNewMessages()
    {
      Pop3 lPop3 = new Pop3();
      lPop3.Connect(Server, User, Password, _Secure);

      int lCount;
      int lSize;
      lPop3.GetStat(out lCount, out lSize);
      if (lCount == _Count && lSize == _Size) { return null; }

      _Count = lCount;
      _Size = lSize;

      List<Message> lResult = new List<Message>();
      for (int i = lCount; i > 0; i--)
      {
        string lId = lPop3.GetId(i);
        if (_KnownMessages.Contains(lId))
        {
          // Message is known and we can stop
          break;
        }
        else
        {
          Message lMessage = new Message();
          string lFrom, lSubject;
          lPop3.GetHeader(i, out lFrom, out lSubject);
          lMessage.From = lFrom;
          lMessage.Subject = lSubject;
          _KnownMessages.Add(lId);
          lResult.Add(lMessage);
        }
      }

      lPop3.Disconnect();

      if (lResult.Count > 0)
      {
        return lResult;
      }
      else
      {
        return null;
      }
    }

  }


  internal class Pop3Exception : System.ApplicationException
  {
    public Pop3Exception(string str)
      : base(str)
    {
    }
  }


  internal class Pop3 : TcpClient
  {

    private SslStream _Stream;


    public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
    {
      if (sslPolicyErrors == SslPolicyErrors.None)
        return true;

      Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

      // Do not allow this client to communicate with unauthenticated servers.
      return false;
    }


    public void Connect(string server, string username, string password, bool secure)
    {
      string message;
      string response;

      if (!secure)
      {
        Connect(server, 110);
      }
      else
      {
        Connect(server, 995);
        _Stream = new SslStream(GetStream(), false, new RemoteCertificateValidationCallback(ValidateServerCertificate), null);
        _Stream.AuthenticateAsClient(server);
      }

      response = Response("\r\n");
      if (response.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(response);
      }

      message = "USER " + username + "\r\n";
      Write(message);
      response = Response("\r\n");
      if (response.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(response);
      }

      message = "PASS " + password + "\r\n";
      Write(message);
      response = Response("\r\n");
      if (response.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(response);
      }
    }


    public void Disconnect()
    {
      string message;
      string response;
      message = "QUIT\r\n";
      Write(message);
      response = Response("\r\n");
      if (response.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(response);
      }
    }


    public void GetStat(out int count, out int size)
    {
      count = 0;
      size = 0;

      Write("STAT\r\n");
      string lResponse = Response("\r\n");

      if (string.IsNullOrEmpty(lResponse) ||
          lResponse.Length < 3 ||
          lResponse.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(lResponse);
      }

      string[] lParts = lResponse.Split(' ');
      count = int.Parse(lParts[1]);
      size = int.Parse(lParts[2]);
    }


    public string GetId(int messageNumber)
    {
      Write(string.Format("UIDL {0}\r\n", messageNumber));
      string lResponse = Response("\r\n");

      if (string.IsNullOrEmpty(lResponse) ||
          lResponse.Length < 3 ||
          lResponse.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(lResponse);
      }

      string[] lParts = lResponse.Split(' ');
      return lParts[2];
    }


    public void GetHeader(int messageNumber, out string from, out string subject)
    {
      Write(string.Format("TOP {0} 0\r\n", messageNumber));
      string lResponse = Response("\r\n.\r\n");

      if (string.IsNullOrEmpty(lResponse) ||
        lResponse.Length < 3 ||
        lResponse.Substring(0, 3) != "+OK")
      {
        throw new Pop3Exception(lResponse);
      }

      int lFromIndex = lResponse.IndexOf("From: ") + 6;
      int lFromEndIndex = lResponse.IndexOf("\r\n", lFromIndex);
      if (lFromEndIndex > lFromIndex)
      {
        from = lResponse.Substring(lFromIndex, lFromEndIndex - lFromIndex);
      }
      else
      {
        from = "";
      }

      int lSubjectIndex = lResponse.IndexOf("Subject: ") + 9;
      int lSubjectEndIndex = lResponse.IndexOf("\r\n", lSubjectIndex);
      if (lSubjectEndIndex > lSubjectIndex)
      {
        subject = lResponse.Substring(lSubjectIndex, lSubjectEndIndex - lSubjectIndex);
      }
      else
      {
        subject = "";
      }
    }


    private void Write(string message)
    {
      System.Text.ASCIIEncoding en = new System.Text.ASCIIEncoding();

      byte[] WriteBuffer = new byte[1024];
      WriteBuffer = en.GetBytes(message);

      if (_Stream == null)
      {
        NetworkStream stream = GetStream();
        stream.Write(WriteBuffer, 0, WriteBuffer.Length);
        stream.Flush();
      }
      else
      {
        _Stream.Write(WriteBuffer, 0, WriteBuffer.Length);
        _Stream.Flush();
      }
    }


    private string Response(string endDelimiter)
    {
      ASCIIEncoding lEnc = new ASCIIEncoding();
      StringBuilder lResponse = new StringBuilder();

      if (_Stream == null)
      {
        NetworkStream lStream = GetStream();
        byte[] lBuffer = new byte[128];
        int lBufferCount;

        lBufferCount = lStream.Read(lBuffer, 0, 128);
        while (true && lBufferCount > 0)
        {
          lResponse.Append(lEnc.GetString(lBuffer, 0, lBufferCount));
          if (lResponse.ToString().Contains(endDelimiter)) { break; }
          lBufferCount = lStream.Read(lBuffer, 0, 128);
        }
      }
      else
      {
        byte[] lBuffer = new byte[128];
        int lBufferCount;

        lBufferCount = _Stream.Read(lBuffer, 0, 128);
        while (true && lBufferCount > 0)
        {
          lResponse.Append(lEnc.GetString(lBuffer, 0, lBufferCount));
          if (lResponse.ToString().Contains(endDelimiter)) { break; }
          lBufferCount = _Stream.Read(lBuffer, 0, 128);
        }
      }

      return lResponse.ToString();
    }

  }

}