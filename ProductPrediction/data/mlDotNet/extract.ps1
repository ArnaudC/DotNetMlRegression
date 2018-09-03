param(
	[parameter(Position=0,Mandatory=$true)]
	[ValidateRange(0, [int]::MaxValue)]
	[int]$start,
	[parameter(Position=1,Mandatory=$true)]
	[ValidateRange(0, [int]::MaxValue)]
	[int]$end,
	[parameter(Position=2,Mandatory=$false)]
	[string]$inputFile = ".\train.csv",
	[parameter(Position=3,Mandatory=$false)]
	[string]$outputFile = ".\out.csv"
)

Get-Content -Path $inputFile -Encoding UTF8 | Select-Object -Index (0..0) > $outputFile # header
Get-Content -Path $inputFile -Encoding UTF8 | Select-Object -Index ($start..$end) >> $outputFile # lines
