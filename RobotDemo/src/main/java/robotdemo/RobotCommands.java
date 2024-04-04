package robotdemo;

import java.awt.AWTException;
import java.awt.MouseInfo;
import java.awt.Point;
import java.awt.PointerInfo;
import java.awt.Robot;
import java.awt.event.InputEvent;
import java.awt.event.KeyEvent;

class RobotCommands {
    
    public static void CTRL_C(Robot r){
        r.keyPress(KeyEvent.VK_CONTROL);
        r.keyPress(KeyEvent.VK_C);
        r.keyRelease(KeyEvent.VK_C);
        r.keyRelease(KeyEvent.VK_CONTROL);
    }
    
    public static void CTRL_V(Robot r){
        r.keyPress(KeyEvent.VK_CONTROL);
        r.keyPress(KeyEvent.VK_V);
        r.keyRelease(KeyEvent.VK_V);
        r.keyRelease(KeyEvent.VK_CONTROL);
    }
    
    public static void CTRL_A(Robot r){
        r.keyPress(KeyEvent.VK_CONTROL);
        r.keyPress(KeyEvent.VK_A);
        r.keyRelease(KeyEvent.VK_A);
        r.keyRelease(KeyEvent.VK_CONTROL);
    }
    
    public static void Tab(Robot r){
        r.keyPress(KeyEvent.VK_TAB);
        r.keyRelease(KeyEvent.VK_TAB);
    }
    
    public static void Backspace(Robot r){
        r.keyPress(KeyEvent.VK_BACK_SPACE);
        r.keyRelease(KeyEvent.VK_BACK_SPACE);
    }
    
    public static void Enter(Robot r){
        r.keyPress(KeyEvent.VK_ENTER);
        r.keyRelease(KeyEvent.VK_ENTER);
    }
    
    public static void Space(Robot r){
        r.keyPress(KeyEvent.VK_SPACE);
        r.keyRelease(KeyEvent.VK_SPACE);
    }
    
    public static void dragIcon(Robot r, int start_x, int start_y, int final_x, int final_y){
        r.mouseMove(start_x, start_y);
        r.mousePress(InputEvent.BUTTON1_DOWN_MASK);
        r.mouseMove(final_x, final_y);
        r.mouseRelease(InputEvent.BUTTON1_DOWN_MASK);
    }
    
    public static void LeftClick(Robot r){
        r.mousePress(InputEvent.BUTTON1_DOWN_MASK);
        r.mouseRelease(InputEvent.BUTTON1_DOWN_MASK);
        r.mousePress(InputEvent.BUTTON1_DOWN_MASK);
        r.mouseRelease(InputEvent.BUTTON1_DOWN_MASK);
    }
    
    public static void typeString(Robot r, String str){
        
        r.setAutoDelay(50);
        int i = 0;
        
        for(i = 0; i < str.length(); i++){
            char c = str.charAt(i);
            int keyCode = KeyEvent.getExtendedKeyCodeForChar(c);
            r.keyPress(keyCode);
            r.keyRelease(keyCode); 
        }
    }
        
    public static void GetLocation(){
        PointerInfo pointer = MouseInfo.getPointerInfo();
        Point point = pointer.getLocation();
        int x = (int) point.getX();
        int y = (int) point.getY();

        System.out.println(x + ", " + y);
    }
    
    public static void main(String[] args) throws AWTException{
        Robot robot = new Robot();
        robot.delay(3000);
        RobotCommands.GetLocation();
    }
    
}
