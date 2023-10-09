using ClosedXML.Excel;

namespace AgendaVeicular.Models;
public class RepositorySugestaoModel
{
    public void Inserir(PropertySugestaoModel property)
    {
        
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("Sugest");
        
        int Aux = worksheet.Rows().Count() + 1;

        worksheet.Cell("A" + Aux).Value =  Aux;

        worksheet.Cell("B" + Aux).Value = property.Registros;

        workbook.SaveAs("DataBase/DataBase.xlsx");

    }
    
    public List<PropertySugestaoModel> Listar()
    {
        List<PropertySugestaoModel> Lista = new List<PropertySugestaoModel>();
        

        int i = 0;
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("Sugest");

        while(worksheet.Rows().Count() > i)
        {
            i++;

            PropertySugestaoModel property = new PropertySugestaoModel();

            property.IdAnotacao = worksheet.Cell("A" + i).GetValue<int>();
        
            property.Registros = worksheet.Cell("B" + i).GetValue<string>();
            
            Lista.Add(property);
        }
        if(worksheet.Rows().Count() == 0)
        {
            PropertySugestaoModel property = new PropertySugestaoModel();

            property.Registros = "empty";

            Lista.Add(property);
        }
        
        Lista.Reverse();
        
        return Lista;
    }
   
    public void Deletar(int Id)
    {
        var workbook = new XLWorkbook("DataBase/DataBase.xlsx");
        var worksheet = workbook.Worksheet("Sugest");
        
        worksheet.Cell("B" + Id).Value = "null";

        workbook.SaveAs("DataBase/DataBase.xlsx");
    }
}