/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project;

import java.util.Stack;


/**
 *
 * @author s-sys
 */
public class CreateTree {
    
    public static String InfixToPostFit(String infix)//הופך את התרגיל בביטוי תוכי לביטוי סופי
    {
        StringBuilder postfix=new StringBuilder();  //הכנסת ה סטרינג לסטרינג בוילדר
        char ch;//כל פעם יחזיר לי תו מסוים מהביטוי התוכי
        char ss;
        Stack<Character> s1 = new Stack<Character>();//בנית מחסנית שמכילים טזר
        for (int i = 0;i< infix.length(); i++)//עוברת בלולאה על כל הביטוי
        {
            ch = infix.charAt(i);//מוציא את התו במיקום ה אי מהביטוי
            if (ch == '(')//אם התו הוא סוגרי פתיחה אז דחוף למחסנית
                s1.push( ch);
		else{
            if (ch == ')') {//אם התו הוא סוגר סיום
                while (s1.peek() != '(')//כל עוד הערך העליון במחסנית הוא לא תו סוגר סיום אז מוציאים מהמחסנית ומוספים לביטוי בייצוג סופי
                {
                    ss = s1.pop();
                    postfix.append(ss);
                }
                s1.pop();//הוצאת הסוגר סיום
            }
            else {
                if (IsNumber(ch)) {//אם הערך הוא מספר אז מוסיפים לביטוי הסופי
                    ss = ch;
                    postfix.append(ss);
                }
                else {//אם הערך הוא אופרנד כל עוד סדר הקדימויות של האופרנד קטן מסדר הקדימויות של האופרנד הבא בתור אז תוסיף לביטוי הסופי
                    while (!s1.empty() && pre(ch) <= pre(s1.peek()))
                    {
                        ss = s1.pop();
                        postfix.append(ss);
                    }
                    s1.push( ch);
                }
            }
        }
        }
        while (!s1.empty())//כל עוד המחסנית לא ריקה אז מוסיפים לביטוי הסופי
        {
            ss = s1.pop();
            postfix.append(ss);
        }
        return  postfix.toString();
    }
    public static Node expressionTree(String postfix){//יצירת העץ
        Stack<Node> st = new Stack<Node>();//יצירת מחסנית של עצים
        Node t1,t2,temp;

        for(int i=0;i<postfix.length();i++){//עובר בלולאה על כל הביטוי הסופי
            if(!isOperator(postfix.charAt(i))){//אם הערך מספר אז בונה צומת של עץ שהערך שלו זה המספר ודוחף למחסנית
                temp = new Node(postfix.charAt(i));
                st.push(temp);
            }
            else{//אם הערך  אופרנד
                temp = new Node(postfix.charAt(i));//בונה צומת בעץ שהערך שלה הוא האופרנד
                //מוציא מהמסנית וקובע כתת עץ שמאלי וכתת עץ ימני
                t1 = st.pop();
                t2 = st.pop();

                temp.left = t2;
                temp.right = t1;

                st.push(temp);//דוחף תת עץ זה שמתחיל באופרנד למחסנית
            }

        }
        temp = st.pop();//מוציא את השורש מהמחסנית
        return temp;
    }
    public static boolean IsNumber(char x)//האם מספר
    {
        if(x>='1' && x<='9')
             return true;
        return false;
    }
    public static int pre(char op) {//סדר קדימויות בחשבון
        if (op == '+' || op == '-')return 1;
        if (op == '*' || op == '/')return 2;
        if (op == '^')return 3;
        return 0;
    }
    public static boolean isOperator(char ch){//האם אתה אופרנד (ולא סוגריים)
        if(ch=='+' || ch=='-'|| ch=='*' || ch=='/' || ch=='^'){
            return true;
        }
        return false;
    }
    public static int calculate(double x)
    {
        int sum=0;
        for(int i=0;i<100000;i++)
        {
            sum+=i+x;
        }
        return sum;
    }

}
 