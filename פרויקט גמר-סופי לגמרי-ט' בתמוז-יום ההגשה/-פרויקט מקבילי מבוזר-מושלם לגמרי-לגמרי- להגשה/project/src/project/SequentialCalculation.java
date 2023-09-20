/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Scanner;

/**
 *
 * @author s-sys
 */
public class SequentialCalculation {
    
    public static double CalculateS(Node root) throws InterruptedException, IOException {

        if(CreateTree.IsNumber(root.data)==true)//אם הצומת הזאת בעץ היא מספר אז הוא מחזיר את המספר כיינט
            return ((double)((int)(root.data))-'0');
        double leftResult=CalculateS(root.left);//חשב את הצד השמאלי של העץ
        double rightRest=CalculateS(root.right);//חשב את הצד הימני של העץ
        switch (root.data)//אחרי שיש לך את הסכום של תת העץ השמאלי ושל תת העץ הימני נחזיר את הסכומים עם הפעולה המתאימה
        {
            case '+':
                double x=leftResult+rightRest;
                CreateTree.calculate(x);
                return x;
            case '-':
                double x1=leftResult-rightRest;
                CreateTree.calculate(x1);
                return x1;
            case '*':
                double x2=leftResult*rightRest;
                CreateTree.calculate(x2);
                return x2;
            default:
                double x3=leftResult/rightRest;
                CreateTree.calculate(x3);
                return x3;
        }
    }
    
}
