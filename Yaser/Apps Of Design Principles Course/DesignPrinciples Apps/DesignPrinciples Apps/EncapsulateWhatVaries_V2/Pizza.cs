using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPrinciples_Apps.EncapsulateWhatVaries_V2
{
    public class Pizza
    {

        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;
        private static Pizza Create(string type)
        {
            Pizza pizza;
            if (type.Equals("Cheese"))
                pizza = new Cheese();
            else if(type.Equals("Vegeterian"))
                pizza = new Vegeterian(); // هون بنلاحظ انه لما ضفنا نوع جديد ما غيرنا عالكود غيرنا بمكان واحد فقط - هون- و الباقي ثابت
            else
                pizza = new Chicken();
            return pizza;

            /*
             * هيك بنكون بنصير نغير بس على هاض الفنكشن بدل ما نغير 
             * على كل الاماكن الي رح نستخدم فيها موضوع الاضافات على البيتزا 
             * برمجيا : بنصير نحدد نوع الاوبجكت من هون بدل ما نعد الكود الف مره
            */
        }

        private static Pizza Create2(string type)
        {
            Pizza pizza;
            if (type.Equals(PizzaConstants.CheesePizza))
                pizza = new Cheese();
            else if (type.Equals(PizzaConstants.VegetetianPizza))
                pizza = new Vegeterian(); 
            else 
                pizza = new Chicken();

            return pizza;

            /*
             *  فيه مبدئ اسمه :
             *  Open for extension for modification
             *  يعني اذا بدك تعدل على اشي شغال اعمل بديل عنه و ما تحذفه ولا تعدل عليه
             *  و هاض الفنكشن مثال
             *  اذا بدنا نعدل عال Create
             *  و نحط new logic 
             *  بنستنتج انه بس فصلنا الكود المتغير صرنا نقدر نعمل بدائل لما بدنا نعمل صيانه
             *  
            */
        }
        public static Pizza Order(string type) {

            /*
             * هون المشكلة بالكود , 
             * لانه قائمة البيتزا او المنيو بشكل عام رح تضل تتغير
             * في حال استخدمنا الكود بأكثر من مكان رح نضطر نعدلهن كلهن
             * عشان هيك لازم نستخدم قانون :
             * "يجب عزل الي بتغير عن الاشياء الثابته "
             * => "Logic that keeps changing, candidate to be highly reused"
             * 
            */

            /*
             * لازم نستنتج انه الكود فيه تلوث لانه الفنكشن فيه معلومات و
             * تفاصيل لاغراض مختلفة مما يصعب من صيانتها في المستقبل
             * Polute the code It contains deatils that not important to show
             * الحل: لازم افصل الكود الي بتعرض لتغيير 
            */

            /*
            Pizza pizza;
            if (type.Equals("Cheese"))
                pizza = new Cheese();
            else
                pizza = new Chicken();
            */

            //
            Pizza pizza = Create2(type);

            Prepare();

            Cook();

            Cut();

            return pizza;
        }
        /*
         * هون افترضنا انه عنا اكثر من قائمة 
         * المشكلة اذا اجينا نعدل رح نظطر نعدل بأكثر من مكان
         * هون بنوقع بخطأ اسمه "D.R.Y : don't repeat yourself "
         * بصير الكود صعب الصيانة و اذا نسينا نعدل بمكان ال
         * consistancy
         * رح تنضرب بمقتل و ما رح يكون فيه تكاملية بالنظام
         * رح يصير النظام يعطي نتيجة بمكان و نتيجة مختلفة بمكان اخر
         * 
        public static Pizza Order2(string type)
        {
            Pizza pizza;
            
            if (type.Equals("Cheese"))
                pizza = new Cheese();
            else
                pizza = new Chicken();

            Prepare();
            Cook();
            Cut();
            return pizza;
        }
        */
        private static void Prepare()
        {
            Console.WriteLine("Preparing...");
            Thread.Sleep(600);
            Console.WriteLine("Completed");
        }
        private static void Cook()
        {
            Console.WriteLine("cooking...");
            Thread.Sleep(600);
            Console.WriteLine("Completed");
        }

        private static void Cut()
        {
            Console.WriteLine("cutting & boxing...");
            Thread.Sleep(600);
            Console.WriteLine("Completed");
        }

        public override string ToString()
        {
            return $"\n{Title}" +
                $"\n\t Price: {Price.ToString("C")}";
        }

    
    }
}
