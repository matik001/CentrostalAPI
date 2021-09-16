using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.IRepositories;
using CentrostalAPI.DB.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static CentrostalAPI.DB.Repositories.SteelTypeRepository;

namespace CentrostalAPI.DB.Repositories {
    public class ItemsRepository : GenericRepository<Item>, IItemsRepository {
        public ItemsRepository(ApplicationDbContext context) : base(context) {
        }

        /// assume order includes  orderItems.item
        public void changeAmountFromOrder(Order order) {
            foreach(var orderItem in order.orderItems) {
                orderItem.item.amount += orderItem.amountDelta;
            }
        }


        public static List<Item> stalMiekka() {
            List<Item> list = new List<Item>();

            Item w1_30A = new Item();
            int t = 30;
            w1_30A.current = t;
            w1_30A.name = "TARCZA OSŁANIAJĄCA";
            w1_30A.number = 220747;
            list.Add(w1_30A);

            Item w2_30A = new Item();
            w2_30A.current = t;
            w2_30A.name = "OSŁONA";
            w2_30A.number = 220194;
            list.Add(w2_30A);

            Item w3_30A = new Item();
            w3_30A.current = t;
            w3_30A.name = "NASADKA DYSZY";
            w3_30A.number = 220754;
            list.Add(w3_30A);

            Item w4_30A = new Item();
            w4_30A.current = t;
            w4_30A.name = "DYSZA";
            w4_30A.number = 220193;
            list.Add(w4_30A);

            Item w5_30A = new Item();
            w5_30A.current = t;
            w5_30A.name = "PIERŚCIEŃ ZAWIR.";
            w5_30A.number = 220180;
            list.Add(w5_30A);

            Item w6_30A = new Item();
            w6_30A.current = t;
            w6_30A.name = "ELEKTRODA";
            w6_30A.number = 220192;
            list.Add(w6_30A);

            Item w8_30A = new Item();
            w8_30A.current = t;
            w8_30A.name = "RURKA WODNA";
            w8_30A.number = 220340;
            list.Add(w8_30A);
            //__________________________________

            t = 50;

            Item w1_50A = new Item();
            w1_50A.current = t;
            w1_50A.name = "TARCZA OSŁANIAJĄCA";
            w1_50A.number = 220747;
            list.Add(w1_50A);

            Item w2_50A = new Item();
            w2_50A.current = t;
            w2_50A.name = "OSŁONA";
            w2_50A.number = 220555;
            list.Add(w2_50A);

            Item w3_50A = new Item();
            w3_50A.current = t;
            w3_50A.name = "NASADKA DYSZY";
            w3_50A.number = 220754;
            list.Add(w3_50A);

            Item w4_50A = new Item();
            w4_50A.current = t;
            w4_50A.name = "DYSZA";
            w4_50A.number = 220554;
            list.Add(w4_50A);

            Item w5_50A = new Item();
            w5_50A.current = t;
            w5_50A.name = "PIERŚCIEŃ ZAWIR.";
            w5_50A.number = 220553;
            list.Add(w5_50A);

            Item w6_50A = new Item();
            w6_50A.current = t;
            w6_50A.name = "ELEKTRODA";
            w6_50A.number = 220552;
            list.Add(w6_50A);

            Item w8_50A = new Item();
            w8_50A.current = t;
            w8_50A.name = "RURKA WODNA";
            w8_50A.number = 220340;
            list.Add(w8_50A);

            //__________________________________

            t = 80;

            Item w1_80A = new Item();
            w1_80A.current = t;
            w1_80A.name = "TARCZA OSŁANIAJĄCA";
            w1_80A.number = 220747;
            list.Add(w1_80A);

            Item w2_80A = new Item();
            w2_80A.current = t;
            w2_80A.name = "OSŁONA";
            w2_80A.number = 220189;
            list.Add(w2_80A);

            Item w3_80A = new Item();
            w3_80A.current = t;
            w3_80A.name = "NASADKA DYSZY";
            w3_80A.number = 220756;
            list.Add(w3_80A);

            Item w4_80A = new Item();
            w4_80A.current = t;
            w4_80A.name = "DYSZA";
            w4_80A.number = 220188;
            list.Add(w4_80A);

            Item w5_80A = new Item();
            w5_80A.current = t;
            w5_80A.name = "PIERŚCIEŃ ZAWIR.";
            w5_80A.number = 220179;
            list.Add(w5_80A);

            Item w6_80A = new Item();
            w6_80A.current = t;
            w6_80A.name = "ELEKTRODA";
            w6_80A.number = 220187;
            list.Add(w6_80A);

            Item w7_80A = new Item();
            w7_80A.current = t;
            w7_80A.name = "ELEKTRODA SILVER";
            w7_80A.number = 220566;
            list.Add(w7_80A);

            Item w8_80A = new Item();
            w8_80A.current = t;
            w8_80A.name = "RURKA WODNA";
            w8_80A.number = 220340;
            list.Add(w8_80A);

            //__________________________________

            t = 130;

            Item w1_130A = new Item();
            w1_130A.current = t;
            w1_130A.name = "TARCZA OSŁANIAJĄCA";
            w1_130A.number = 220747;
            list.Add(w1_130A);

            Item w2_130A = new Item();
            w2_130A.current = t;
            w2_130A.name = "OSŁONA";
            w2_130A.number = 220189;
            list.Add(w2_130A);

            Item w3_130A = new Item();
            w3_130A.current = t;
            w3_130A.name = "NASADKA DYSZY";
            w3_130A.number = 220756;
            list.Add(w3_130A);

            Item w4_130A = new Item();
            w4_130A.current = t;
            w4_130A.name = "DYSZA";
            w4_130A.number = 220188;
            list.Add(w4_130A);

            Item w5_130A = new Item();
            w5_130A.current = t;
            w5_130A.name = "PIERŚCIEŃ ZAWIR.";
            w5_130A.number = 220179;
            list.Add(w5_130A);

            Item w6_130A = new Item();
            w6_130A.current = t;
            w6_130A.name = "ELEKTRODA";
            w6_130A.number = 220187;
            list.Add(w6_130A);

            Item w7_130A = new Item();
            w7_130A.current = t;
            w7_130A.name = "ELEKTRODA SILVER";
            w7_130A.number = 220566;
            list.Add(w7_130A);

            Item w8_130A = new Item();
            w8_130A.current = t;
            w8_130A.name = "RURKA WODNA";
            w8_130A.number = 220340;
            list.Add(w8_130A);
            //__________________________________

            t = 200;

            Item w1_200A = new Item();
            w1_200A.current = t;
            w1_200A.name = "TARCZA OSŁANIAJĄCA";
            w1_200A.number = 220747;
            list.Add(w1_200A);

            Item w2_200A = new Item();
            w2_200A.current = t;
            w2_200A.name = "OSŁONA";
            w2_200A.number = 220189;
            list.Add(w2_200A);

            Item w3_200A = new Item();
            w3_200A.current = t;
            w3_200A.name = "NASADKA DYSZY";
            w3_200A.number = 220756;
            list.Add(w3_200A);

            Item w4_200A = new Item();
            w4_200A.current = t;
            w4_200A.name = "DYSZA";
            w4_200A.number = 220188;
            list.Add(w4_200A);

            Item w5_200A = new Item();
            w5_200A.current = t;
            w5_200A.name = "PIERŚCIEŃ ZAWIR.";
            w5_200A.number = 220179;
            list.Add(w5_200A);

            Item w6_200A = new Item();
            w6_200A.current = t;
            w6_200A.name = "ELEKTRODA";
            w6_200A.number = 220187;
            list.Add(w6_200A);

            Item w7_200A = new Item();
            w7_200A.current = t;
            w7_200A.name = "ELEKTRODA SILVER";
            w7_200A.number = 220566;
            list.Add(w7_200A);

            Item w8_200A = new Item();
            w8_200A.current = t;
            w8_200A.name = "RURKA WODNA";
            w8_200A.number = 220340;
            list.Add(w8_200A);

            //__________________________________

            t = 260;

            Item w1_260A = new Item();
            w1_260A.current = t;
            w1_260A.name = "TARCZA OSŁANIAJĄCA";
            w1_260A.number = 220747;
            list.Add(w1_260A);

            Item w2_260A = new Item();
            w2_260A.current = t;
            w2_260A.name = "OSŁONA";
            w2_260A.number = 220189;
            list.Add(w2_260A);

            Item w3_260A = new Item();
            w3_260A.current = t;
            w3_260A.name = "NASADKA DYSZY";
            w3_260A.number = 220756;
            list.Add(w3_260A);

            Item w4_260A = new Item();
            w4_260A.current = t;
            w4_260A.name = "DYSZA";
            w4_260A.number = 220188;
            list.Add(w4_260A);

            Item w5_260A = new Item();
            w5_260A.current = t;
            w5_260A.name = "PIERŚCIEŃ ZAWIR.";
            w5_260A.number = 220179;
            list.Add(w5_260A);

            Item w6_260A = new Item();
            w6_260A.current = t;
            w6_260A.name = "ELEKTRODA";
            w6_260A.number = 220187;
            list.Add(w6_260A);

            Item w7_260A = new Item();
            w7_260A.current = t;
            w7_260A.name = "ELEKTRODA SILVER";
            w7_260A.number = 220566;
            list.Add(w7_260A);

            Item w8_260A = new Item();
            w8_260A.current = t;
            w8_260A.name = "RURKA WODNA";
            w8_260A.number = 220340;
            list.Add(w8_260A);

            //__________________________________

            t = 400;

            Item w1_400A = new Item();
            w1_400A.current = t;
            w1_400A.name = "TARCZA OSŁANIAJĄCA";
            w1_400A.number = 220747;
            list.Add(w1_400A);

            Item w2_400A = new Item();
            w2_400A.current = t;
            w2_400A.name = "OSŁONA";
            w2_400A.number = 220189;
            list.Add(w2_400A);

            Item w3_400A = new Item();
            w3_400A.current = t;
            w3_400A.name = "NASADKA DYSZY";
            w3_400A.number = 220756;
            list.Add(w3_400A);

            Item w4_400A = new Item();
            w4_400A.current = t;
            w4_400A.name = "DYSZA";
            w4_400A.number = 220188;
            list.Add(w4_400A);

            Item w5_400A = new Item();
            w5_400A.current = t;
            w5_400A.name = "PIERŚCIEŃ ZAWIR.";
            w5_400A.number = 220179;
            list.Add(w5_400A);

            Item w6_400A = new Item();
            w6_400A.current = t;
            w6_400A.name = "ELEKTRODA";
            w6_400A.number = 220187;
            list.Add(w6_400A);

            Item w7_400A = new Item();
            w7_400A.current = t;
            w7_400A.name = "ELEKTRODA SILVER";
            w7_400A.number = 220566;
            list.Add(w7_400A);

            Item w8_400A = new Item();
            w8_400A.current = t;
            w8_400A.name = "RURKA WODNA";
            w8_400A.number = 220571;
            list.Add(w8_400A);

            foreach(var item in list) {
                item.steelTypeId = (int)SteelTypesEnum.stalMiekka;
            }
            return list;
        }
        public static List<Item> stalMiekkaBavel() {
            List<Item> list = new List<Item>();

            Item w1_80A = new Item();
            int t = 80;
            w1_80A.current = t;
            w1_80A.name = "TARCZA OSŁANIAJĄCA";
            w1_80A.number = 220637;
            list.Add(w1_80A);

            Item w2_80A = new Item();
            w2_80A.current = t;
            w2_80A.name = "OSŁONA";
            w2_80A.number = 220742;
            list.Add(w2_80A);

            Item w3_80A = new Item();
            w3_80A.current = t;
            w3_80A.name = "NASADKA DYSZY";
            w3_80A.number = 220845;
            list.Add(w3_80A);

            Item w4_80A = new Item();
            w4_80A.current = t;
            w4_80A.name = "DYSZA";
            w4_80A.number = 220806;
            list.Add(w4_80A);

            Item w5_80A = new Item();
            w5_80A.current = t;
            w5_80A.name = "PIERŚCIEŃ ZAWIR.";
            w5_80A.number = 220179;
            list.Add(w5_80A);

            Item w6_80A = new Item();
            w6_80A.current = t;
            w6_80A.name = "ELEKTRODA";
            w6_80A.number = 220802;
            list.Add(w6_80A);

            Item w8_80A = new Item();
            w8_80A.current = t;
            w8_80A.name = "RURKA WODNA";
            w8_80A.number = 220700;
            list.Add(w8_80A);
            //_____________________
            t = 130;

            Item w1_130A = new Item();
            w1_130A.current = t;
            w1_130A.name = "TARCZA OSŁANIAJĄCA";
            w1_130A.number = 220637;
            list.Add(w1_130A);

            Item w2_130A = new Item();
            w2_130A.current = t;
            w2_130A.name = "OSŁONA";
            w2_130A.number = 220742;
            list.Add(w2_130A);

            Item w3_130A = new Item();
            w3_130A.current = t;
            w3_130A.name = "NASADKA DYSZY";
            w3_130A.number = 220740;
            list.Add(w3_130A);

            Item w4_130A = new Item();
            w4_130A.current = t;
            w4_130A.name = "DYSZA";
            w4_130A.number = 220646;
            list.Add(w4_130A);

            Item w5_130A = new Item();
            w5_130A.current = t;
            w5_130A.name = "PIERŚCIEŃ ZAWIR.";
            w5_130A.number = 220179;
            list.Add(w5_130A);

            Item w6_130A = new Item();
            w6_130A.current = t;
            w6_130A.name = "ELEKTRODA";
            w6_130A.number = 220649;
            list.Add(w6_130A);

            Item w8_130A = new Item();
            w8_130A.current = t;
            w8_130A.name = "RURKA WODNA";
            w8_130A.number = 220700;
            list.Add(w8_130A);
            //__________________________________

            t = 200;

            Item w1_200A = new Item();
            w1_200A.current = t;
            w1_200A.name = "TARCZA OSŁANIAJĄCA";
            w1_200A.number = 220637;
            list.Add(w1_200A);

            Item w2_200A = new Item();
            w2_200A.current = t;
            w2_200A.name = "OSŁONA";
            w2_200A.number = 220658;
            list.Add(w2_200A);

            Item w3_200A = new Item();
            w3_200A.current = t;
            w3_200A.name = "NASADKA DYSZY";
            w3_200A.number = 220845;
            list.Add(w3_200A);

            Item w4_200A = new Item();
            w4_200A.current = t;
            w4_200A.name = "DYSZA";
            w4_200A.number = 220659;
            list.Add(w4_200A);

            Item w5_200A = new Item();
            w5_200A.current = t;
            w5_200A.name = "PIERŚCIEŃ ZAWIR.";
            w5_200A.number = 220353;
            list.Add(w5_200A);

            Item w6_200A = new Item();
            w6_200A.current = t;
            w6_200A.name = "ELEKTRODA";
            w6_200A.number = 220662;
            list.Add(w6_200A);

            Item w8_200A = new Item();
            w8_200A.current = t;
            w8_200A.name = "RURKA WODNA";
            w8_200A.number = 220700;
            list.Add(w8_200A);

            //__________________________________

            t = 260;

            Item w1_260A = new Item();
            w1_260A.current = t;
            w1_260A.name = "TARCZA OSŁANIAJĄCA";
            w1_260A.number = 220637;
            list.Add(w1_260A);

            Item w2_260A = new Item();
            w2_260A.current = t;
            w2_260A.name = "OSŁONA";
            w2_260A.number = 220741;
            list.Add(w2_260A);

            Item w3_260A = new Item();
            w3_260A.current = t;
            w3_260A.name = "NASADKA DYSZY";
            w3_260A.number = 220740;
            list.Add(w3_260A);

            Item w4_260A = new Item();
            w4_260A.current = t;
            w4_260A.name = "DYSZA";
            w4_260A.number = 220542;
            list.Add(w4_260A);

            Item w5_260A = new Item();
            w5_260A.current = t;
            w5_260A.name = "PIERŚCIEŃ ZAWIR.";
            w5_260A.number = 220436;
            list.Add(w5_260A);

            Item w6_260A = new Item();
            w6_260A.current = t;
            w6_260A.name = "ELEKTRODA";
            w6_260A.number = 220541;
            list.Add(w6_260A);

            Item w8_260A = new Item();
            w8_260A.current = t;
            w8_260A.name = "RURKA WODNA";
            w8_260A.number = 220571;
            list.Add(w8_260A);

            foreach(var item in list) {
                item.steelTypeId = (int)SteelTypesEnum.stalMiekkaBavel;
            }
            return list;
        }
        public static List<Item> stalNierdzewna() {
            List<Item> list = new List<Item>();


            Item w1_45A = new Item();
            int t = 45;
            w1_45A.current = t;
            w1_45A.name = "TARCZA OSŁANIAJĄCA";
            w1_45A.number = 220747;
            list.Add(w1_45A);

            Item w2_45A = new Item();
            w2_45A.current = t;
            w2_45A.name = "OSŁONA";
            w2_45A.number = 220202;
            list.Add(w2_45A);

            Item w3_45A = new Item();
            w3_45A.current = t;
            w3_45A.name = "NASADKA DYSZY";
            w3_45A.number = 220755;
            list.Add(w3_45A);

            Item w4_45A = new Item();
            w4_45A.current = t;
            w4_45A.name = "DYSZA";
            w4_45A.number = 220201;
            list.Add(w4_45A);

            Item w5_45A = new Item();
            w5_45A.current = t;
            w5_45A.name = "PIERŚCIEŃ ZAWIR.";
            w5_45A.number = 220180;
            list.Add(w5_45A);

            Item w6_45A = new Item();
            w6_45A.current = t;
            w6_45A.name = "ELEKTRODA";
            w6_45A.number = 220308;
            list.Add(w6_45A);

            Item w8_45A = new Item();
            w8_45A.current = t;
            w8_45A.name = "RURKA WODNA";
            w8_45A.number = 220340;
            list.Add(w8_45A);
            //_____________________
            t = 60;

            Item w1_60A = new Item();
            w1_60A.current = t;
            w1_60A.name = "TARCZA OSŁANIAJĄCA";
            w1_60A.number = 220747;
            list.Add(w1_60A);

            Item w2_60A = new Item();
            w2_60A.current = t;
            w2_60A.name = "OSŁONA";
            w2_60A.number = 220815;
            list.Add(w2_60A);

            Item w3_60A = new Item();
            w3_60A.current = t;
            w3_60A.name = "NASADKA DYSZY";
            w3_60A.number = 220814;
            list.Add(w3_60A);

            Item w4_60A = new Item();
            w4_60A.current = t;
            w4_60A.name = "DYSZA";
            w4_60A.number = 220847;
            list.Add(w4_60A);

            Item w5_60A = new Item();
            w5_60A.current = t;
            w5_60A.name = "PIERŚCIEŃ ZAWIR.";
            w5_60A.number = 220180;
            list.Add(w5_60A);

            Item w6_60A = new Item();
            w6_60A.current = t;
            w6_60A.name = "ELEKTRODA";
            w6_60A.number = 220339;
            list.Add(w6_60A);

            Item w8_60A = new Item();
            w8_60A.current = t;
            w8_60A.name = "RURKA WODNA";
            w8_60A.number = 220340;
            list.Add(w8_60A);
            //__________________________________
            t = 80;

            Item w1_80A = new Item();
            w1_80A.current = t;
            w1_80A.name = "TARCZA OSŁANIAJĄCA";
            w1_80A.number = 220747;
            list.Add(w1_80A);

            Item w2_80A = new Item();
            w2_80A.current = t;
            w2_80A.name = "OSŁONA";
            w2_80A.number = 220338;
            list.Add(w2_80A);

            Item w3_80A = new Item();
            w3_80A.current = t;
            w3_80A.name = "NASADKA DYSZY";
            w3_80A.number = 220755;
            list.Add(w3_80A);

            Item w4_80A = new Item();
            w4_80A.current = t;
            w4_80A.name = "DYSZA";
            w4_80A.number = 220337;
            list.Add(w4_80A);

            Item w5_80A = new Item();
            w5_80A.current = t;
            w5_80A.name = "PIERŚCIEŃ ZAWIR.";
            w5_80A.number = 220179;
            list.Add(w5_80A);

            Item w6_80A = new Item();
            w6_80A.current = t;
            w6_80A.name = "ELEKTRODA";
            w6_80A.number = 220339;
            list.Add(w6_80A);

            Item w8_80A = new Item();
            w8_80A.current = t;
            w8_80A.name = "RURKA WODNA";
            w8_80A.number = 220340;
            list.Add(w8_80A);
            //__________________________________
            t = 130;

            Item w1_130A = new Item();
            w1_130A.current = t;
            w1_130A.name = "TARCZA OSŁANIAJĄCA";
            w1_130A.number = 220747;
            list.Add(w1_130A);

            Item w2_130A = new Item();
            w2_130A.current = t;
            w2_130A.name = "OSŁONA";
            w2_130A.number = 220198;
            list.Add(w2_130A);

            Item w3_130A = new Item();
            w3_130A.current = t;
            w3_130A.name = "NASADKA DYSZY";
            w3_130A.number = 220755;
            list.Add(w3_130A);

            Item w4_130A = new Item();
            w4_130A.current = t;
            w4_130A.name = "DYSZA";
            w4_130A.number = 220197;
            list.Add(w4_130A);

            Item w5_130A = new Item();
            w5_130A.current = t;
            w5_130A.name = "PIERŚCIEŃ ZAWIR.";
            w5_130A.number = 220179;
            list.Add(w5_130A);

            Item w6_130A = new Item();
            w6_130A.current = t;
            w6_130A.name = "ELEKTRODA";
            w6_130A.number = 220307;
            list.Add(w6_130A);

            Item w8_130A = new Item();
            w8_130A.current = t;
            w8_130A.name = "RURKA WODNA";
            w8_130A.number = 220340;
            list.Add(w8_130A);
            //__________________________________
            t = 200;

            Item w1_200A = new Item();
            w1_200A.current = t;
            w1_200A.name = "TARCZA OSŁANIAJĄCA";
            w1_200A.number = 220637;
            list.Add(w1_200A);

            Item w2_200A = new Item();
            w2_200A.current = t;
            w2_200A.name = "OSŁONA";
            w2_200A.number = 220762;
            list.Add(w2_200A);

            Item w3_200A = new Item();
            w3_200A.current = t;
            w3_200A.name = "NASADKA DYSZY";
            w3_200A.number = 220758;
            list.Add(w3_200A);

            Item w4_200A = new Item();
            w4_200A.current = t;
            w4_200A.name = "DYSZA";
            w4_200A.number = 220343;
            list.Add(w4_200A);

            Item w5_200A = new Item();
            w5_200A.current = t;
            w5_200A.name = "PIERŚCIEŃ ZAWIR.";
            w5_200A.number = 220342;
            list.Add(w5_200A);

            Item w6_200A = new Item();
            w6_200A.current = t;
            w6_200A.name = "ELEKTRODA";
            w6_200A.number = 220307;
            list.Add(w6_200A);

            Item w8_200A = new Item();
            w8_200A.current = t;
            w8_200A.name = "RURKA WODNA";
            w8_200A.number = 220340;
            list.Add(w8_200A);
            //__________________________________
            t = 260;

            Item w1_260A = new Item();
            w1_260A.current = t;
            w1_260A.name = "TARCZA OSŁANIAJĄCA";
            w1_260A.number = 220637;
            list.Add(w1_260A);

            Item w2_260A = new Item();
            w2_260A.current = t;
            w2_260A.name = "OSŁONA";
            w2_260A.number = 220763;
            list.Add(w2_260A);

            Item w3_260A = new Item();
            w3_260A.current = t;
            w3_260A.name = "NASADKA DYSZY";
            w3_260A.number = 220758;
            list.Add(w3_260A);

            Item w4_260A = new Item();
            w4_260A.current = t;
            w4_260A.name = "DYSZA";
            w4_260A.number = 220406;
            list.Add(w4_260A);

            Item w5_260A = new Item();
            w5_260A.current = t;
            w5_260A.name = "PIERŚCIEŃ ZAWIR.";
            w5_260A.number = 220405;
            list.Add(w5_260A);

            Item w6_260A = new Item();
            w6_260A.current = t;
            w6_260A.name = "ELEKTRODA";
            w6_260A.number = 220307;
            list.Add(w6_260A);

            Item w8_260A = new Item();
            w8_260A.current = t;
            w8_260A.name = "RURKA WODNA";
            w8_260A.number = 220340;
            list.Add(w8_260A);
            //__________________________________
            t = 400;

            Item w1_400A = new Item();
            w1_400A.current = t;
            w1_400A.name = "TARCZA OSŁANIAJĄCA";
            w1_400A.number = 220637;
            list.Add(w1_400A);

            Item w2_400A = new Item();
            w2_400A.current = t;
            w2_400A.name = "OSŁONA";
            w2_400A.number = 220707;
            list.Add(w2_400A);

            Item w3_400A = new Item();
            w3_400A.current = t;
            w3_400A.name = "NASADKA DYSZY";
            w3_400A.number = 220712;
            list.Add(w3_400A);

            Item w4_400A = new Item();
            w4_400A.current = t;
            w4_400A.name = "DYSZA";
            w4_400A.number = 220708;
            list.Add(w4_400A);

            Item w5_400A = new Item();
            w5_400A.current = t;
            w5_400A.name = "PIERŚCIEŃ ZAWIR.";
            w5_400A.number = 220405;
            list.Add(w5_400A);

            Item w6_400A = new Item();
            w6_400A.current = t;
            w6_400A.name = "ELEKTRODA";
            w6_400A.number = 220709;
            list.Add(w6_400A);

            Item w8_400A = new Item();
            w8_400A.current = t;
            w8_400A.name = "RURKA WODNA";
            w8_400A.number = 220571;
            list.Add(w8_400A);

            foreach(var item in list) {
                item.steelTypeId = (int)SteelTypesEnum.stalNierdzewna;
            }
            return list;
        }
        public static List<Item> stalNierdzewnaBavel() {
            List<Item> list = new List<Item>();

            int t = 130;

            Item w1_130A = new Item();
            w1_130A.current = t;
            w1_130A.name = "TARCZA OSŁANIAJĄCA";
            w1_130A.number = 220637;
            list.Add(w1_130A);

            Item w2_130A = new Item();
            w2_130A.current = t;
            w2_130A.name = "OSŁONA";
            w2_130A.number = 220738;
            list.Add(w2_130A);

            Item w3_130A = new Item();
            w3_130A.current = t;
            w3_130A.name = "NASADKA DYSZY";
            w3_130A.number = 220739;
            list.Add(w3_130A);

            Item w4_130A = new Item();
            w4_130A.current = t;
            w4_130A.name = "DYSZA";
            w4_130A.number = 220656;
            list.Add(w4_130A);

            Item w5_130A = new Item();
            w5_130A.current = t;
            w5_130A.name = "PIERŚCIEŃ ZAWIR.";
            w5_130A.number = 220179;
            list.Add(w5_130A);

            Item w6_130A = new Item();
            w6_130A.current = t;
            w6_130A.name = "ELEKTRODA";
            w6_130A.number = 220606;
            list.Add(w6_130A);

            Item w8_130A = new Item();
            w8_130A.current = t;
            w8_130A.name = "RURKA WODNA";
            w8_130A.number = 220571;
            list.Add(w8_130A);
            //__________________________________
            t = 260;

            Item w1_260A = new Item();
            w1_260A.current = t;
            w1_260A.name = "TARCZA OSŁANIAJĄCA";
            w1_260A.number = 220637;
            list.Add(w1_260A);

            Item w2_260A = new Item();
            w2_260A.current = t;
            w2_260A.name = "OSŁONA";
            w2_260A.number = 220738;
            list.Add(w2_260A);

            Item w3_260A = new Item();
            w3_260A.current = t;
            w3_260A.name = "NASADKA DYSZY";
            w3_260A.number = 220739;
            list.Add(w3_260A);

            Item w4_260A = new Item();
            w4_260A.current = t;
            w4_260A.name = "DYSZA";
            w4_260A.number = 220607;
            list.Add(w4_260A);

            Item w5_260A = new Item();
            w5_260A.current = t;
            w5_260A.name = "PIERŚCIEŃ ZAWIR.";
            w5_260A.number = 220405;
            list.Add(w5_260A);

            Item w6_260A = new Item();
            w6_260A.current = t;
            w6_260A.name = "ELEKTRODA";
            w6_260A.number = 220606;
            list.Add(w6_260A);

            Item w8_260A = new Item();
            w8_260A.current = t;
            w8_260A.name = "RURKA WODNA";
            w8_260A.number = 220571;
            list.Add(w8_260A);
            //__________________________________
            t = 400;

            Item w1_400A = new Item();
            w1_400A.current = t;
            w1_400A.name = "TARCZA OSŁANIAJĄCA";
            w1_400A.number = 220637;
            list.Add(w1_400A);

            Item w2_400A = new Item();
            w2_400A.current = t;
            w2_400A.name = "OSŁONA";
            w2_400A.number = 220707;
            list.Add(w2_400A);

            Item w3_400A = new Item();
            w3_400A.current = t;
            w3_400A.name = "NASADKA DYSZY";
            w3_400A.number = 220712;
            list.Add(w3_400A);

            Item w4_400A = new Item();
            w4_400A.current = t;
            w4_400A.name = "DYSZA";
            w4_400A.number = 220708;
            list.Add(w4_400A);

            Item w5_400A = new Item();
            w5_400A.current = t;
            w5_400A.name = "PIERŚCIEŃ ZAWIR.";
            w5_400A.number = 220405;
            list.Add(w5_400A);

            Item w6_400A = new Item();
            w6_400A.current = t;
            w6_400A.name = "ELEKTRODA";
            w6_400A.number = 220709;
            list.Add(w6_400A);

            Item w8_400A = new Item();
            w8_400A.current = t;
            w8_400A.name = "RURKA WODNA";
            w8_400A.number = 220571;
            list.Add(w8_400A);
            //__________________________________

            foreach(var item in list) {
                item.steelTypeId = (int)SteelTypesEnum.stalNierdzewnaBavel;
            }
            return list;
        }
        public static List<Item> aluminium() {
            List<Item> list = new List<Item>();

            int t = 45;
            Item w1_45A = new Item();
            w1_45A.current = t;
            w1_45A.name = "TARCZA OSŁANIAJĄCA";
            w1_45A.number = 220747;
            list.Add(w1_45A);

            Item w2_45A = new Item();
            w2_45A.current = t;
            w2_45A.name = "OSŁONA";
            w2_45A.number = 220202;
            list.Add(w2_45A);

            Item w3_45A = new Item();
            w3_45A.current = t;
            w3_45A.name = "NASADKA DYSZY";
            w3_45A.number = 220756;
            list.Add(w3_45A);

            Item w4_45A = new Item();
            w4_45A.current = t;
            w4_45A.name = "DYSZA";
            w4_45A.number = 220201;
            list.Add(w4_45A);

            Item w5_45A = new Item();
            w5_45A.current = t;
            w5_45A.name = "PIERŚCIEŃ ZAWIR.";
            w5_45A.number = 220180;
            list.Add(w5_45A);

            Item w6_45A = new Item();
            w6_45A.current = t;
            w6_45A.name = "ELEKTRODA";
            w6_45A.number = 220308;
            list.Add(w6_45A);

            Item w8_45A = new Item();
            w8_45A.current = t;
            w8_45A.name = "RURKA WODNA";
            w8_45A.number = 220340;
            list.Add(w8_45A);
            //_____________________
            t = 130;

            Item w1_130A = new Item();
            w1_130A.current = t;
            w1_130A.name = "TARCZA OSŁANIAJĄCA";
            w1_130A.number = 220747;
            list.Add(w1_130A);

            Item w2_130A = new Item();
            w2_130A.current = t;
            w2_130A.name = "OSŁONA";
            w2_130A.number = 220198;
            list.Add(w2_130A);

            Item w3_130A = new Item();
            w3_130A.current = t;
            w3_130A.name = "NASADKA DYSZY";
            w3_130A.number = 220755;
            list.Add(w3_130A);

            Item w4_130A = new Item();
            w4_130A.current = t;
            w4_130A.name = "DYSZA";
            w4_130A.number = 220197;
            list.Add(w4_130A);

            Item w5_130A = new Item();
            w5_130A.current = t;
            w5_130A.name = "PIERŚCIEŃ ZAWIR.";
            w5_130A.number = 220179;
            list.Add(w5_130A);

            Item w6_130A = new Item();
            w6_130A.current = t;
            w6_130A.name = "ELEKTRODA";
            w6_130A.number = 220307 + 220181;
            list.Add(w6_130A);

            Item w8_130A = new Item();
            w8_130A.current = t;
            w8_130A.name = "RURKA WODNA";
            w8_130A.number = 220340;
            list.Add(w8_130A);
            //__________________________________
            t = 200;

            Item w1_200A = new Item();
            w1_200A.current = t;
            w1_200A.name = "TARCZA OSŁANIAJĄCA";
            w1_200A.number = 220637;
            list.Add(w1_200A);

            Item w2_200A = new Item();
            w2_200A.current = t;
            w2_200A.name = "OSŁONA";
            w2_200A.number = 220762;
            list.Add(w2_200A);

            Item w3_200A = new Item();
            w3_200A.current = t;
            w3_200A.name = "NASADKA DYSZY";
            w3_200A.number = 220759;
            list.Add(w3_200A);

            Item w4_200A = new Item();
            w4_200A.current = t;
            w4_200A.name = "DYSZA";
            w4_200A.number = 220346;
            list.Add(w4_200A);

            Item w5_200A = new Item();
            w5_200A.current = t;
            w5_200A.name = "PIERŚCIEŃ ZAWIR.";
            w5_200A.number = 220342;
            list.Add(w5_200A);

            Item w6_200A = new Item();
            w6_200A.current = t;
            w6_200A.name = "ELEKTRODA";
            w6_200A.number = 220307;
            list.Add(w6_200A);

            Item w8_200A = new Item();
            w8_200A.current = t;
            w8_200A.name = "RURKA WODNA";
            w8_200A.number = 220340;
            list.Add(w8_200A);
            //__________________________________
            t = 260;

            Item w1_260A = new Item();
            w1_260A.current = t;
            w1_260A.name = "TARCZA OSŁANIAJĄCA";
            w1_260A.number = 220637;
            list.Add(w1_260A);

            Item w2_260A = new Item();
            w2_260A.current = t;
            w2_260A.name = "OSŁONA";
            w2_260A.number = 220763;
            list.Add(w2_260A);

            Item w3_260A = new Item();
            w3_260A.current = t;
            w3_260A.name = "NASADKA DYSZY";
            w3_260A.number = 220758;
            list.Add(w3_260A);

            Item w4_260A = new Item();
            w4_260A.current = t;
            w4_260A.name = "DYSZA";
            w4_260A.number = 220406;
            list.Add(w4_260A);

            Item w5_260A = new Item();
            w5_260A.current = t;
            w5_260A.name = "PIERŚCIEŃ ZAWIR.";
            w5_260A.number = 220405;
            list.Add(w5_260A);

            Item w6_260A = new Item();
            w6_260A.current = t;
            w6_260A.name = "ELEKTRODA";
            w6_260A.number = 220307;
            list.Add(w6_260A);

            Item w8_260A = new Item();
            w8_260A.current = t;
            w8_260A.name = "RURKA WODNA";
            w8_260A.number = 220340;
            list.Add(w8_260A);
            //__________________________________
            t = 400;

            Item w1_400A = new Item();
            w1_400A.current = t;
            w1_400A.name = "TARCZA OSŁANIAJĄCA";
            w1_400A.number = 220637;
            list.Add(w1_400A);

            Item w2_400A = new Item();
            w2_400A.current = t;
            w2_400A.name = "OSŁONA";
            w2_400A.number = 220707;
            list.Add(w2_400A);

            Item w3_400A = new Item();
            w3_400A.current = t;
            w3_400A.name = "NASADKA DYSZY";
            w3_400A.number = 220712;
            list.Add(w3_400A);

            Item w4_400A = new Item();
            w4_400A.current = t;
            w4_400A.name = "DYSZA";
            w4_400A.number = 220708;
            list.Add(w4_400A);

            Item w5_400A = new Item();
            w5_400A.current = t;
            w5_400A.name = "PIERŚCIEŃ ZAWIR.";
            w5_400A.number = 220405;
            list.Add(w5_400A);

            Item w6_400A = new Item();
            w6_400A.current = t;
            w6_400A.name = "ELEKTRODA";
            w6_400A.number = 220709;
            list.Add(w6_400A);

            Item w8_400A = new Item();
            w8_400A.current = t;
            w8_400A.name = "RURKA WODNA";
            w8_400A.number = 220571;
            list.Add(w8_400A);
            //__________________________________

            foreach(var item in list) {
                item.steelTypeId = (int)SteelTypesEnum.aluminium;
            }
            return list;
        }

        public static void seed(EntityTypeBuilder<Item> builder) {
            var t = new[] { stalMiekka(), stalMiekkaBavel(), stalNierdzewna(), stalNierdzewnaBavel(), aluminium() }
                        .SelectMany(a => a).ToList();
            List<Item> items = new List<Item>();
            int nextIdx = 1;
            foreach(var item in t) {
                var original = new Item() {
                    id = nextIdx++,
                    amount = 0,
                    current = item.current,
                    isOriginal = true,
                    name = item.name,
                    number = item.number,
                    steelTypeId = item.steelTypeId
                };
                var substitute = new Item() {
                    id = nextIdx++,
                    amount = 0,
                    current = item.current,
                    isOriginal = false,
                    name = item.name,
                    number = item.number,
                    steelTypeId = item.steelTypeId
                };
                items.Add(original);
                items.Add(substitute);
            }
            builder.HasData(items);
        }

    }
}
