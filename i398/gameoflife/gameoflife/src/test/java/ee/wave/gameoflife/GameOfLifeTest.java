package ee.wave.gameoflife;

import static org.hamcrest.CoreMatchers.*;
import static org.junit.Assert.*;

import org.junit.Test;

public class GameOfLifeTest {

	@Test
	public void initializeFrameFromStrings() {
		String[] matrix = {"--X", "XX-", "X-X"};
		Frame frame = new Frame(matrix);
		
		assertThat(frame.width, is(equalTo(3)));
		assertThat(frame.height, is(equalTo(3)));
		
		boolean[][] expectedSlots = {{false, false, true}, {true, true, false}, {true, false, true}};
		assertThat(frame.slots, is(equalTo(expectedSlots)));
	}
	
	@Test
	public void nextFrameIsCalculated() {
		Frame frame = getFrame("X");
		assertThat(frame.nextFrame().toString(), is(equalTo("-")));
	}
	
	@Test
	public void equalsForSameFramesReturnsTrue() {
		Frame a = getFrame("XX", "--");
		Frame b = getFrame("XX", "--");
		assertThat(a.equals(b), is(equalTo(true)));
	}
	
	@Test
	public void toStringReturnsFrameAsAString() {
		Frame frame = getFrame("XX", "--", "XX");
		assertThat(frame.toString(), is(equalTo("XX--XX")));
	}
	
	@Test
	public void aliveSlotsCountAroundWorks() {
		Frame frame = getFrame(	"XXXX-",
								"XXX--",
								"XXX--",
								"X----");
		
		assertThat(frame.aliveSlotsCountAround(4, 0), is(equalTo(1)));
		assertThat(frame.aliveSlotsCountAround(1, 1), is(equalTo(8)));
		assertThat(frame.aliveSlotsCountAround(5, 5), is(equalTo(0)));
	}
	
	@Test
	public void isAliveChecksIfSlotIsExistingAndAlive() {
		Frame frame = getFrame("XX", "--");
		
		assertThat( frame.isAlive(0,0), is(equalTo(true)) );
		assertThat( frame.isAlive(1,1), is(equalTo(false)) );
	}
	
	@Test
	public void nextStatusTests() {
		Frame frame = getFrame("X");

		boolean nextStatus = frame.nextStatus(true, 0);
		assertThat(nextStatus, is(equalTo(false)));

		nextStatus = frame.nextStatus(true, 1);
		assertThat(nextStatus, is(equalTo(false)));
		
		nextStatus = frame.nextStatus(true, 2);
		assertThat(nextStatus, is(equalTo(true)));

		nextStatus = frame.nextStatus(true, 3);
		assertThat(nextStatus, is(equalTo(true)));
		
		nextStatus = frame.nextStatus(false, 3);
		assertThat(nextStatus, is(equalTo(true)));
		
		nextStatus = frame.nextStatus(true, 4);
		assertThat(nextStatus, is(equalTo(false)));
	}
	

    @Test
    public void stillWorksCorrectly() {
        Frame frame = getFrame("------",
                               "--XX--",
                               "-X--X-",
                               "--XX--",
                               "------");


        assertThat(frame.nextFrame(), is(equalTo(frame)));
    }

    @Test
    public void pulsarWorksCorrectly() {
        Frame frame = getFrame("------",
                               "-XX---",
                               "-X----",
                               "----X-",
                               "---XX-",
                               "------");

        Frame expected = getFrame("------",
                                  "-XX---",
                                  "-XX---",
                                  "---XX-",
                                  "---XX-",
                                  "------");

        assertThat(frame.nextFrame(), is(equalTo(expected)));
        assertThat(frame.nextFrame().nextFrame(), is(equalTo(frame)));
    }

    @Test
    public void gliderWorksCorrectly() {
        Frame frame1 = getFrame("-X----",
                                "--XX--",
                                "-XX---",
                                "------");

        Frame frame2 = getFrame("--X---",
                                "---X--",
                                "-XXX--",
                                "------");

        Frame frame3 = getFrame("------",
                                "-X-X--",
                                "--XX--",
                                "--X---");

        assertThat(frame1.nextFrame(), is(equalTo(frame2)));
        assertThat(frame2.nextFrame(), is(equalTo(frame3)));
    }

    private Frame getFrame(String ... rows) {
    	return new Frame(rows);
    }
}