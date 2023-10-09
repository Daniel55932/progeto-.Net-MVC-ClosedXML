using ClosedXML.Excel;

namespace AgendaVeicular.Models;
public class RepositoryAnotacaoModel
{
    public void Inserir(PropertyAnotacaoModel property)
    {
        
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");
        
        int Aux = worksheet.Rows().Count() + 1;

        worksheet.Cell("A" + Aux).Value =  Aux;

        worksheet.Cell("B" + Aux).Value = property.DataAtual;

        worksheet.Cell("C" + Aux).Value = property.Registros;

        workbook.SaveAs("DataBase/DataBase.xlsx");

    }
    
    public List<PropertyAnotacaoModel> Listar()
    {
        List<PropertyAnotacaoModel> Lista = new List<PropertyAnotacaoModel>();
        

        int i = 0;
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");

        while(worksheet.Rows().Count() > i)
        {
            i++;

            PropertyAnotacaoModel property = new PropertyAnotacaoModel();

            property.IdAnotacao = worksheet.Cell("A" + i).GetValue<int>();
        
            property.DataAtual = worksheet.Cell("B" + i).GetValue<string>();

            property.Registros = worksheet.Cell("C" + i).GetValue<string>();
            
            Lista.Add(property);
        }
        if(worksheet.Rows().Count() == 0)
        {
            PropertyAnotacaoModel property = new PropertyAnotacaoModel();

            property.Registros = "empty";

            Lista.Add(property);
        }
        
        Lista.Reverse();
        
        return Lista;
    }
   
    public void Editar(PropertyAnotacaoModel property)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");
        
        worksheet.Cell("B" + property.IdAnotacao).Value = property.DataAtual;

        worksheet.Cell("C" + property.IdAnotacao).Value = property.Registros;

        workbook.SaveAs("DataBase/DataBase.xlsx");
    }

    public PropertyAnotacaoModel BuscaPorId(int Id)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");

        PropertyAnotacaoModel property = new PropertyAnotacaoModel();
        
        property.IdAnotacao = worksheet.Cell("A" + Id).GetValue<int>();

        property.DataAtual = worksheet.Cell("B" + Id).GetValue<string>();

        property.Registros = worksheet.Cell("C" + Id).GetValue<string>();

        return property;
    }
    
    public void Deletar(int Id)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("DB2");
        
        worksheet.Cell("B" + Id).Value = "null";

        worksheet.Cell("C" + Id).Value = "null";

        workbook.SaveAs("DataBase/DataBase.xlsx");
    }
}