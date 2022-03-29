package govno;

import java.awt.Color;
import java.awt.Graphics;
import javax.swing.JFrame;

public class sva extends JFrame
{
    public static void main(final String[] args) {
        final sva frame = new sva();
        System.out.println("\u0421\u0442\u0430\u0440\u0442");
        frame.setBounds(100, 100, 1200, 800);
        frame.setDefaultCloseOperation(2);
        frame.setVisible(true);
        System.out.println("\u0424\u0438\u043d\u0438\u0448");
    }

    @Override
    public void paint(final Graphics g) {
        super.paint(g);
        g.drawLine(900, 300, 1000, 300);
        g.drawLine(1000, 300, 1000, 400);
        g.drawLine(1000, 300, 1000, 200);
        g.drawLine(1000, 300, 1100, 300);
        g.drawLine(900, 400, 1000, 400);
        g.drawLine(1100, 300, 1100, 400);
        g.drawLine(900, 300, 900, 200);
        g.drawLine(1000, 200, 1100, 200);
        g.setColor(Color.blue);
        g.fillRect(200, 350, 100, 200);
        g.fillOval(187, 225, 125, 125);
        g.drawLine(200, 375, 100, 250);
        g.drawLine(225, 550, 225, 675);
        g.drawLine(275, 550, 275, 675);
        g.setColor(Color.black);
        g.fillRect(237, 300, 10, 5);
    }
}