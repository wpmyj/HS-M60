using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TestData
    {
            public List<Model.TSalPayType> plist ;
            public Model.TSalSale sal;
            public List<Model.TSalSalePlu> salplu;
            public Model.UserInfo user;
            public TestData()
            {
                #region 支付方式
                plist = new List<Model.TSalPayType>();
                Model.TSalPayType p = new Model.TSalPayType();
                p.ISCHANGE = "1";
                p.PAYCODE = "0";
                p.PAYNAME = "现金";
                p.PAYTYPE = "0";
                p.PAYTYPENAME = "现金";
                plist.Add(p);
                Model.TSalPayType p1 = new Model.TSalPayType();
                p1.ISCHANGE = "0";
                p1.PAYCODE = "2";
                p1.PAYTYPE = "2";
                p1.PAYNAME = "银行卡";
                p1.PAYTYPENAME = "银行卡";
                plist.Add(p1);
                Model.TSalPayType p2 = new Model.TSalPayType();
                p2.ISCHANGE = "0";
                p2.PAYCODE = "1";
                p2.PAYTYPE = "1";
                p2.PAYNAME = "提货卡";
                p2.PAYTYPENAME = "提货卡";
                plist.Add(p2);
                Model.TSalPayType p3 = new Model.TSalPayType();
                p3.ISCHANGE = "0";
                p3.PAYCODE = "3";
                p3.PAYTYPE = "3";
                p3.PAYNAME = "定金";
                p3.PAYTYPENAME = "定金";
                plist.Add(p3);
                Model.TSalPayType p4 = new Model.TSalPayType();
                p4.ISCHANGE = "0";
                p4.PAYCODE = "4";
                p4.PAYTYPE = "4";
                p4.PAYNAME = "购物券";
                p4.PAYTYPENAME = "购物券";
                plist.Add(p4);
                Model.TSalPayType p5 = new Model.TSalPayType();
                p5.ISCHANGE = "0";
                p5.PAYCODE = "5";
                p5.PAYTYPE = "5";
                p5.PAYNAME = "IC卡";
                p5.PAYTYPENAME = "IC卡";
                plist.Add(p5);
                #endregion

                #region 流水
                sal=new Model.TSalSale();
                sal.YSTOTAL = "1500";
                sal.YHTOTAL = "100";
                sal.SALENO = "0000000001";
                sal.VIPCARDNO = "12345678";
                #endregion

                #region 流水明细 
                salplu = new List<TSalSalePlu>();
                Model.TSalSalePlu plu1 = new Model.TSalSalePlu();
                plu1.FSPRICE = "1000";
                plu1.PLUCODE = "000001";
                plu1.PLUNAME = "商品A";
                plu1.PRICE = "1000";
                plu1.SALENO = "0000000001";
                plu1.UNIT = "件";
                plu1.XSCOUNT = "1";

                Model.TSalSalePlu plu2 = new Model.TSalSalePlu();
                plu2.FSPRICE = "100";
                plu2.PLUCODE = "000002";
                plu2.PLUNAME = "商品B";
                plu2.PRICE = "100";
                plu2.SALENO = "0000000001";
                plu2.UNIT = "件";
                plu2.XSCOUNT = "5";

                salplu.Add(plu1);
                salplu.Add(plu2);
                #endregion

                #region 用户信息
                user = new Model.UserInfo();
                user.UserCode = "001";
                user.USERNAME = "收款员";
                user.Password = "000";
                user.Rights = new UserRight[] {
                    new UserRight("01","1","停车收费"),
                    new UserRight("02","1","消费支付")
                };
                #endregion

            }
    }
}
