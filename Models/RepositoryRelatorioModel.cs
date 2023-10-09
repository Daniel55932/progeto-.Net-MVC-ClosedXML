using ClosedXML.Excel;

namespace AgendaVeicular.Models;
public class RepositoryRelatorioModel
{

    public void InserirKm(PropertyRelatorioModel property)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");

        worksheet.Cell("B1").Value = property.Km;
            
        workbook.SaveAs("DataBase/DataBase.xlsx");
    }
    
    public void CriaDiretorio()
    {
        //Criar a pasta e o DataBase.xlsx, se não existir.
        string Diretorio = "DataBase/DataBase.xlsx";

        FileInfo file = new FileInfo(Diretorio);
        if (! file.Exists)
        {
            var workbook = new XLWorkbook();
            workbook.Worksheets.Add("DB1");
            workbook.Worksheets.Add("DB2");
            workbook.Worksheets.Add("Sugest");

            workbook.SaveAs("DataBase/DataBase.xlsx");
        }
    }
    public void InseriKm()
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");

        if(worksheet.Rows().Count() == 0)
        {
            worksheet.Cell("A1").Value = 1;

            worksheet.Cell("B1").Value = 0;

            workbook.SaveAs("DataBase/DataBase.xlsx");
        }
    }
    

    public void Inserir(PropertyRelatorioModel property)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");
        
        int Aux = worksheet.Rows().Count() + 1;

        worksheet.Cell("A" + Aux).Value =  Aux;

        worksheet.Cell("B" + Aux).Value = property.DataAtual;

        worksheet.Cell("C" + Aux).Value = property.Veiculo;

        worksheet.Cell("D" + Aux).Value = property.PecasNome;

        worksheet.Cell("E" + Aux).Value = property.PecasDurabilidade;

        worksheet.Cell("F" + Aux).Value = property.PecasSubstituicao;

        worksheet.Cell("G" + Aux).FormulaA1 = "=SUM(" + "E" + Aux + "+" + "F" + Aux + ")";

        worksheet.Cell("H" + Aux).FormulaA1 = "=SUM(" + "G" + Aux + "-" + "B1)";

        worksheet.Cell("I" + Aux).FormulaA1 = "=SUM(" + "E" + Aux + "-" + "B1)";
    
        workbook.SaveAs("DataBase/DataBase.xlsx");
    }
    
    public List<PropertyRelatorioModel> Listar()
    {
        List<PropertyRelatorioModel> Lista = new List<PropertyRelatorioModel>();
    
        int i = 1;
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");
        
        while(worksheet.Rows().Count() > i)
        {
            i++;

            PropertyRelatorioModel property = new PropertyRelatorioModel();

            property.IdRelatorio = worksheet.Cell("A" + i).GetValue<int>();
        
            property.DataAtual = worksheet.Cell("B" + i).GetValue<string>();

            property.Veiculo = worksheet.Cell("C" + i).GetValue<string>();

            property.PecasNome = worksheet.Cell("D" + i).GetValue<string>();

            property.PecasDurabilidade = worksheet.Cell("E" + i).GetValue<int>();

            property.PecasSubstituicao = worksheet.Cell("F" + i).GetValue<int>();

            property.SomaE_F = worksheet.Cell("G" + i).GetValue<int>();

            property.SubtraiG_B1 = worksheet.Cell("H" + i).GetValue<int>();

            property.SubtraiE_B1 = worksheet.Cell("I" + i).GetValue<int>();

            property.Km = worksheet.Cell("B1").GetValue<int>();
            
            Lista.Add(property);
        }

        if(worksheet.Rows().Count() == 1)
        {
            PropertyRelatorioModel property = new PropertyRelatorioModel();

            property.PecasNome = "empty";

            Lista.Add(property);
        }

        Lista.Reverse();
        
        return Lista;
    }

    public void Editar(PropertyRelatorioModel property)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");
        
        worksheet.Cell("B" + property.IdRelatorio).Value = property.DataAtual;

        worksheet.Cell("C" + property.IdRelatorio).Value = property.Veiculo;

        worksheet.Cell("D" + property.IdRelatorio).Value = property.PecasNome;

        worksheet.Cell("E" + property.IdRelatorio).Value = property.PecasDurabilidade;

        worksheet.Cell("F" + property.IdRelatorio).Value = property.PecasSubstituicao;

        workbook.SaveAs("DataBase/DataBase.xlsx");
    }

    public PropertyRelatorioModel BuscaPorId(int Id)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");

        PropertyRelatorioModel property = new PropertyRelatorioModel();
        
        property.IdRelatorio = worksheet.Cell("A" + Id).GetValue<int>();

        property.DataAtual = worksheet.Cell("B" + Id).GetValue<string>();

        property.Veiculo = worksheet.Cell("C" + Id).GetValue<string>();

        property.PecasNome = worksheet.Cell("D" + Id).GetValue<string>();

        property.PecasDurabilidade = worksheet.Cell("E" + Id).GetValue<int>();

        property.PecasSubstituicao = worksheet.Cell("F" + Id).GetValue<int>();

        return property;
    }
    
    public void Deletar(int Id)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB1");
        
        worksheet.Cell("B" + Id).Value = "null";

        worksheet.Cell("C" + Id).Value = "null";

        worksheet.Cell("D" + Id).Value = "null";

        worksheet.Cell("E" + Id).Value = 0;

        worksheet.Cell("F" + Id).Value = 0;

        workbook.SaveAs("DataBase/DataBase.xlsx");
    }
}