package ee.wave.invoice;

import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.CoreMatchers.is;
import static org.junit.Assert.assertThat;
import static org.mockito.Mockito.*;

import java.math.BigDecimal;
import java.text.*;
import java.util.ArrayList;
import java.util.Date;

import org.hamcrest.*;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.*;
import org.mockito.runners.MockitoJUnitRunner;

@RunWith(MockitoJUnitRunner.class)
public class InvoiceRowGeneratorTest {

    @Mock InvoiceRowDao dao;

    @InjectMocks InvoiceRowGenerator generator;

    @Test
    public void lastRowGetsTheRemainder() {

        generator.generateRowsFor(new BigDecimal(10),
                                  asDate("2012-02-15"),
                                  asDate("2012-04-02"));

        verify(dao, times(2)).save(argThat(getMatcherForAmount(3)));
        verify(dao).save(argThat(getMatcherForAmount(4)));

        // verify that there are no more calls
    }
    
    @Test
    public void datesCalculationIsCorrect() {
    	ArrayList<Date> dates;
    	dates = generator.getPaymentDates(asDate("2012-01-02"), asDate("2012-03-01"));
    	ArrayList<Date> expectedDates = new ArrayList<Date>(); 
    	expectedDates.add(asDate("2012-01-02"));
    	expectedDates.add(asDate("2012-02-01"));
    	expectedDates.add(asDate("2012-03-01"));
    	assertThat(dates, is(equalTo(expectedDates)));
    }
    
    @Test
    public void whenAmountsAreEventTotalIsDividedCorrectly() {
        generator.generateRowsFor(new BigDecimal(9),
                asDate("2012-02-15"),
                asDate("2012-04-02"));

		verify(dao, times(3)).save(argThat(getMatcherForAmount(3)));
    }
    
    @Test
    public void whenAmountsAreUnevenTotalIsDividedCorrectly() {
        generator.generateRowsFor(new BigDecimal(11),
                asDate("2012-02-15"),
                asDate("2012-04-02"));

		verify(dao, times(2)).save(argThat(getMatcherForAmount(3)));
		verify(dao, times(1)).save(argThat(getMatcherForAmount(5)));
    }
    
    @Test
    public void whenTotalIsSmallerThanRangeFor3PerMonth() {
        generator.generateRowsFor(new BigDecimal(6),
                asDate("2012-01-01"),
                asDate("2012-03-01"));

		verify(dao, times(2)).save(argThat(getMatcherForAmount(3)));
    }
    
    @Test
    public void when3AmountsWouldBeLessThan2TheyWillBeMadeCreater() {
        generator.generateRowsFor(new BigDecimal(8),
                asDate("2012-01-01"),
                asDate("2012-03-01"));

		verify(dao, times(2)).save(argThat(getMatcherForAmount(4)));
    }

    
    @Test
    public void whenAmountIsSmallerThan2Only1PaymentIsDone() {
        generator.generateRowsFor(new BigDecimal(2),
                asDate("2012-01-01"),
                asDate("2012-03-01"));

		verify(dao, times(1)).save(argThat(getMatcherForAmount(2)));
    }
    

    private Matcher<InvoiceRow> getMatcherForAmount(final Integer amount) {

        // Matcher-i näide. Sama põhimõttega tuleb teha teine
        // Kuupäeva jaoks

        return new TypeSafeMatcher<InvoiceRow>() {

            @Override
            protected boolean matchesSafely(InvoiceRow item) {
                return amount.equals(item.amount.intValue());
            }

            //@Override
            public void describeTo(Description description) {
                description.appendText(String.valueOf(amount));
            }
        };
    }
    

    private Matcher<InvoiceRow> getMatcherForDate(final Date date) {

        return new TypeSafeMatcher<InvoiceRow>() {

            @Override
            protected boolean matchesSafely(InvoiceRow item) {
                return date.equals(item.date);
            }

            //@Override
            public void describeTo(Description description) {
                description.appendText(String.valueOf(date));
            }
        };
    }

    public static Date asDate(String date) {
        try {
            return new SimpleDateFormat("yyyy-MM-dd").parse(date);
        } catch (ParseException e) {
            throw new RuntimeException(e);
        }
    }

    
  
}