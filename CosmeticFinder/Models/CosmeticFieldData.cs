using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CosmeticFinder.Models;

namespace CosmeticFinder.Models
{
    public class CosmeticFieldData<TField> where TField : CosmeticField, new()
    {
        //the list made here is of type CosmeticField. So I think TField
        //can take objects of any type...
        // public JobFieldData<TField> Babla = new JobFieldData();  so the TField could be of any type
        //ex: public JobFieldData<Employer> Employers { get; set; } = new JobFieldData<Employer>(); found in 

        /* where T : struct
        The type argument must be a value type. Any value type except Nullable can be specified. See Using Nullable Types (C# Programming Guide) for more information.
        
        where T : class
        The type argument must be a reference type, including any class, interface, delegate, or array type. (See note below.)
       
        **where T : new() The type argument must have a public parameterless constructor. When used in conjunction with other constraints, the new() constraint must be specified last.
       
        where T : [base class name]
        The type argument must be or derive from the specified base class.
        
        where T : [interface name]
        The type argument must be or implement the specified interface. Multiple interface constraints can be specified. The constraining interface can also be generic.
        
        where T : U
        The type argument supplied for T must be or derive from the argument supplied for U. This is called a naked type constraint.

 * 
 * */
private List<TField> allFields = new List<TField>();

private void Add(TField field)
{
allFields.Add(field);

}

public List<TField> ToList()
{
return allFields;
}

public TField Find(int id)
{
var results = from field in allFields
              where field.ID == id
              select field;
return results.Single();

}
internal TField AddUnique(string fieldValue)
{
var results = from field in allFields
              where field.Value.Equals(fieldValue)
              select field;
TField theField;

if(!results.Any())
{
    theField = new TField();
    theField.Value = fieldValue;

    Add(theField);
}
else
{
    theField = results.Single();

}
return theField;
}
}
}
