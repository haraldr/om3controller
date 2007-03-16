<?php
if(!file_exists("count.txt"))
{$counter=fopen("count.txt", "a");}
else
{$counter=fopen("count.txt", "r+");}
$count=fgets($counter,100);
$count=$count+1;
rewind($counter);
fputs($counter,$count);
fclose($counter);
?>