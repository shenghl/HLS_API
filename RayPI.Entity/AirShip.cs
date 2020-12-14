using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Models
{
    ///<summary>
    ///飞船类
    ///</summary>
    [SugarTable("AirShip")]
    public partial class AirShip
    {
           public AirShip(){


           }
           /// <summary>
           /// Desc:自增主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int AId {get;set;}

           /// <summary>
           /// Desc:飞船编号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Code {get;set;}

           /// <summary>
           /// Desc:飞船名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Name {get;set;}

           /// <summary>
           /// Desc:制造时间
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime ProdtTime {get;set;}

    }
}
