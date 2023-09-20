/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package project;

/**
 *
 * @author s-sys
 */
public class Node {//מחלקה של עץ
    char data;//הערך כלומר מספר או אופרטורים
    Node left,right;//בן שמאלי ובן ימני מסוג עץ
    public Node(char data){
        this.data = data;
        left = right = null;
    }
}
