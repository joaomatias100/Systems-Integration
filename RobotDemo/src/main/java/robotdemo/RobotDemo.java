package robotdemo;

import java.awt.AWTException;
import java.awt.Robot;
import java.awt.event.KeyEvent;

public class RobotDemo {

    public static void main(String[] args) throws AWTException {
        Robot robot = new Robot();
        
        robot.keyPress(KeyEvent.VK_WINDOWS);
        robot.delay(500);
        robot.keyRelease(KeyEvent.VK_WINDOWS);
        robot.delay(500);
        
        robot.keyPress(KeyEvent.VK_N);
        robot.keyPress(KeyEvent.VK_O);
        robot.keyPress(KeyEvent.VK_T);
        robot.keyPress(KeyEvent.VK_E);
        robot.keyPress(KeyEvent.VK_P);
        robot.keyPress(KeyEvent.VK_A);
        robot.keyPress(KeyEvent.VK_D);
        
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_ENTER);
        robot.delay(500);
        robot.keyRelease(KeyEvent.VK_ENTER);
        robot.delay(500);
        
        robot.keyPress(KeyEvent.VK_H);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_E);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_L);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_L);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_O);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_SPACE);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_W);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_O);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_R);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_L);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_D);
        robot.delay(500);
        robot.keyPress(KeyEvent.VK_PERIOD);
        robot.delay(500);
    }
}
