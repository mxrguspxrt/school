package ee.wave.invoice;

import java.math.BigDecimal;
import java.util.*;

public class InvoiceRowGenerator {

    @SuppressWarnings("unused")
    private InvoiceRowDao invoiceRowDao;

    public void generateRowsFor(BigDecimal amount, Date start, Date end) {
        // kood, mis read (InvoiceRow) genereerib ja salvestab, tuleb siia.
    	
    	ArrayList<Date> paymentDates = getPaymentDates(start, end);
    	ArrayList<InvoiceRow> invoiceRows = buildInvoiceRows(amount, paymentDates);
    	
    	for (InvoiceRow invoiceRow : invoiceRows) {
    		invoiceRowDao.save(invoiceRow);
    	}
    	
    }
    
    public ArrayList<InvoiceRow> buildInvoiceRows(BigDecimal totalAmount, ArrayList<Date> paymentDates) {
    	
    	int rowCount = paymentDates.size();
    	int currentRow = 1;
    	BigDecimal leftToPayAmount = totalAmount;
    	BigDecimal mediumPayment = new BigDecimal(totalAmount.doubleValue() / rowCount);
    	mediumPayment = new BigDecimal(mediumPayment.intValue());
    	
    	if (mediumPayment.compareTo(new BigDecimal(3)) < 0 
    			&& totalAmount.compareTo(new BigDecimal(3)) > 0) {
    		mediumPayment = new BigDecimal(3);
    	}
    	
    	ArrayList<InvoiceRow> invoiceRows = new ArrayList<InvoiceRow>();
    	
    	for (Date paymentDate : paymentDates) {
    		BigDecimal currentPayment;
    		
    		if (leftToPayAmount.equals(0)) {
    			break;
    		}
    		
    		if (currentRow==rowCount) {
    			currentPayment = leftToPayAmount;
    		} else {
    			currentPayment = mediumPayment;
    		}
    		
    		InvoiceRow invoiceRow = new InvoiceRow(currentPayment, paymentDate);
    		invoiceRows.add(invoiceRow);
    		leftToPayAmount = leftToPayAmount.subtract(invoiceRow.amount);
    		
    		currentRow += 1;
    	}
    	
    	if (invoiceRows.size() > 1 && isSmaller(invoiceRows.get(invoiceRows.size()-1).amount, new BigDecimal(3))) {
    		paymentDates.remove(rowCount-1);
    		return buildInvoiceRows(totalAmount, paymentDates);
    	}
    	
    	return invoiceRows;
    }
    
    public boolean isSmaller(BigDecimal a, BigDecimal b) {
    	return a.compareTo(b) < 0; 
    }

    public ArrayList<Date> getPaymentDates(Date start, Date end) {
    	ArrayList<Date> dates = new ArrayList<Date>();
    	Date cursor = start;
    	
    	while (cursor.before(end) || cursor.equals(end)) {
    		dates.add(cursor);
    		cursor = getNextDate(cursor);
    	}
    	
    	return dates;
    }
    
    public Date getNextDate(Date date) {
    	Calendar cal = Calendar.getInstance();
    	cal.setTime(date);
    	cal.add(Calendar.MONTH, 1);
    	cal.set(Calendar.DAY_OF_MONTH, 1);
    	return cal.getTime();
    }

    
}