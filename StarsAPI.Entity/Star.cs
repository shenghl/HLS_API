using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///星辰表
    ///</summary>
    [SugarTable("Star")]
    public partial class Star
    {
           public Star(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int SId {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? Age {get;set;}

    }
}
