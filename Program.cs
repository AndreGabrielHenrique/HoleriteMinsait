int opcao=0;
string separador=new string('-',56);
System.Console.WriteLine(separador);
Console.ForegroundColor=ConsoleColor.DarkGreen;
System.Console.WriteLine("Bem vindo ao sistema de geração de holerites da Minsait.");
Console.ResetColor();
while(opcao==0)
{
    System.Console.WriteLine(separador);
    System.Console.WriteLine("1) Gerar holerite");
    System.Console.WriteLine("2) Encerrar sistema");    
    opcao=int.Parse(Console.ReadLine());
    switch(opcao)
    {
        case 1:
            processaHolerite();
            opcao=0;
            break;
        case 2:
            System.Console.WriteLine(separador);
            System.Console.WriteLine("Muito obrigado.");
            System.Console.WriteLine(separador);
            break;
    }
    Console.ReadKey();
    Console.Clear();
}
static void processaHolerite()
{
    string separador=new string('-',56);
    System.Console.WriteLine(separador);
    System.Console.WriteLine("Informe valor do salário");
    double salario=double.Parse(Console.ReadLine());
    System.Console.WriteLine(separador);
    System.Console.WriteLine("Informe as horas trabalhadas");
    int horas=int.Parse(Console.ReadLine());
    System.Console.WriteLine(separador);
    System.Console.WriteLine("Tem vale transporte?");
    string possuivaletransporte=Console.ReadLine();
    System.Console.WriteLine(separador);
    System.Console.WriteLine("Usou convênio?");
    string usouconvenio=Console.ReadLine();
    double valorHora=CalculaValorHora(horas,salario);
    double adiantamento=CalculaAdiantamento(salario);
    double valeTransporte=CalculaValeTransporte(salario,possuivaletransporte);
    double convenio=CalculaConvenio(salario,usouconvenio);
    double INSS=CalculaINSS(salario);
    double IR=CalculaIR(salario);
    double RAT=CalculaRAT(salario);
    double FGTS=CalculaFGTS(salario);
    double salarioBruto=salario;
    double totalDescontos=IR+INSS+FGTS+valeTransporte+convenio+adiantamento+RAT+35;
    double salarioLiquido=salarioBruto-totalDescontos;
    ImprimeHolerite(salarioBruto,IR,INSS,FGTS,RAT,convenio,totalDescontos,salarioLiquido,valeTransporte,adiantamento);
}

static void ImprimeHolerite(double salarioBruto,
double IR,
double INSS,
double RAT,
double FGTS,
double convenio,
double totalDescontos,
double salarioLiquido,
double valeTransporte,
double adiantamento)
{
    string separador=new string('-',56);
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.Cyan;
    System.Console.WriteLine($"Salário Bruto:                   {salarioBruto.ToString("C")}");
    System.Console.WriteLine($"Vale Transporte:                 {valeTransporte.ToString("C")}");
    System.Console.WriteLine($"IRRF:                            {IR.ToString("C")}");
    System.Console.WriteLine($"INSS:                            {INSS.ToString("C")}");
    System.Console.WriteLine($"RAT:                             {RAT.ToString("C")}");
    System.Console.WriteLine($"FGTS:                            {FGTS.ToString("C")}");
    System.Console.WriteLine($"Uso do convênio:                 {convenio.ToString("C")}");
    System.Console.WriteLine($"Contribuição Assistencial:       {35.ToString("C")}");
    System.Console.WriteLine($"Adiantamento Quinzenal:          {adiantamento.ToString("C")}");
    Console.ResetColor();
    System.Console.WriteLine(separador);
    Console.ForegroundColor=ConsoleColor.Green;
    System.Console.WriteLine($"Total Descontos:                 {totalDescontos.ToString("C")}");
    System.Console.WriteLine($"Salário Líquido:                 {salarioLiquido.ToString("C")}");
    Console.ResetColor();
    System.Console.WriteLine(separador);
}

static double CalculaValorHora(int horas,double salario)=>salario/horas;
static double CalculaAdiantamento(double salario)=>salario*0.40;
static double CalculaValeTransporte(double salario,string possuivaletransporte)
{
    if(possuivaletransporte=="Sim"||possuivaletransporte=="SIM"||possuivaletransporte=="sim")
    {
        return salario*0.06;
    }
    return 0;
}
static double CalculaConvenio(double salario,string usouconvenio) 
{
    if(usouconvenio=="Sim"||usouconvenio=="SIM"||usouconvenio=="sim")
    {
        return 35;
    }
    return 0;
}
static double CalculaRAT(double salario)=>salario*0.08;
static double CalculaFGTS(double salario)=>salario*0.015;
static double CalculaINSS(double salario)
{
    string separador=new string('-',56);
    if(salario<0)
    {
        System.Console.WriteLine(separador);
        Console.ForegroundColor=ConsoleColor.Red;
        System.Console.WriteLine("Salário não pode ser menor que zero");
        Console.ResetColor();
        return 0;
    }
    if(salario<=1412)
        return salario*0.075;
    else if(salario>1413&&salario<=2666)
        return salario*0.09;
    else if(salario>2667&&salario<=4000)
        return salario*0.12;
    else if(salario>4001&&salario<=7786)
        return salario*0.14;
    return 0;
}
static double CalculaIR(double salario)
{
    string separador=new string('-',56);
    if(salario<0)
    {
        System.Console.WriteLine(separador);
        Console.ForegroundColor=ConsoleColor.Red;
        System.Console.WriteLine("Salário não pode ser menor que zero");
        Console.ResetColor();
        return 0;
    }
    if(salario<=1903)
        return 0;
    else if(salario>1904&&salario<=2866)
        return salario*0.075;
    else if(salario>2867&&salario<=3751)
        return salario*0.15;
    else if(salario>3752&&salario<=4664)
        return salario*0.225;
    else if(salario>4665)
        return salario*0.275;
    return 0;
}