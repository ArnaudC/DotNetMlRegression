param(
	[parameter(Position=0,Mandatory=$true)]
	[string]$fileName
)

$nlines = 0;
#read file by 1000 lines at a time
gc $fileName -read 1000 | % { $nlines += $_.Length }; 
[string]::Format("{0} has {1} lines", $fileName, $nlines)
