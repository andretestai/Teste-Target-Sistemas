double faturamentoSP = 67836.43;
double faturamentoRJ = 36678.66;
double faturamentoMG = 29229.88;
double faturamentoES = 27165.48;
double faturamentoOutros = 19849.53;

double faturamentoTotal = faturamentoSP + faturamentoRJ + faturamentoMG + faturamentoES + faturamentoOutros;

double percentualSP = (faturamentoSP / faturamentoTotal) * 100;
double percentualRJ = (faturamentoRJ / faturamentoTotal) * 100;
double percentualMG = (faturamentoMG / faturamentoTotal) * 100;
double percentualES = (faturamentoES / faturamentoTotal) * 100;
double percentualOutros = (faturamentoOutros / faturamentoTotal) * 100;

Console.WriteLine("Percentual de faturamento por estado:");
Console.WriteLine($"SP: {percentualSP:F2}%");
Console.WriteLine($"RJ: {percentualRJ:F2}%");
Console.WriteLine($"MG: {percentualMG:F2}%");
Console.WriteLine($"ES: {percentualES:F2}%");
Console.WriteLine($"Outros: {percentualOutros:F2}%");