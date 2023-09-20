/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project;

import java.io.FileWriter;
import java.io.IOException;
import java.io.Writer;


/**
 *
 * @author s-sys
 */
public class ParallelCalculation {
    double leftResult;
    double rightResult;
    public double CalculateMM(Node root)  {

        if(CreateTree.IsNumber(root.data)==true)//אם אתה בצומת שהערך שלה מספר אז תחזיר את המספר ביינט
            return ((double)((int)(root.data))-'0');
        Thread t1=new Thread(new Runnable(){
            @Override
            public void run() {//טרייד שמחשב את חישוב תת העץ השמאלי
                ParallelCalculation c=new ParallelCalculation();
                leftResult= c.CalculateMM(root.left);
            }
        });
        Thread t2=new Thread(new Runnable() {//טרייד שמחשב את חישוב תת העץ הימני
            @Override
            public void run() {
                ParallelCalculation c=new ParallelCalculation();
                rightResult=  c.CalculateMM(root.right);
            }
        });
        t1.start();//הפעלת הטרייד
        t2.start();
        try {//המתנה עד ששני הטרדים יסימו בשביל המשך התרגיל
            t1.join();
            t2.join();
        } catch (InterruptedException e) {
            throw new RuntimeException(e);
        }
        //System.out.println("the parameter is "+root.data);
        switch (root.data)//אחרי שחזרו החישובים של תת הץ השמאלי ותת העץ הימני מפעילים את פעולת החישוב של צומת זו עם התוצאות שחזרו
        {
            case '+':double x=leftResult+rightResult;
                CreateTree.calculate(x);
                return x;
            case '-':double x1=leftResult-rightResult;
                CreateTree.calculate(x1);
                return x1;
            case '*':double x2=leftResult*rightResult;
                CreateTree.calculate(x2);
                return x2;
            default:double x3=leftResult/rightResult;
                CreateTree.calculate(x3);
                return x3;
        }
    }
   
}
