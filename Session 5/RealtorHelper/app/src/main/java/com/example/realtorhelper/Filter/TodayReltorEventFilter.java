package com.example.realtorhelper.Filter;

import com.example.realtorhelper.RealtorEvent;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class TodayReltorEventFilter implements RealtorEventFilter {
    @Override
    public List<RealtorEvent> use(List<RealtorEvent> list) {
        ArrayList<RealtorEvent> result = new ArrayList<>();
        for (RealtorEvent event : list) {
            Calendar todayDate = Calendar.getInstance();
            if(event.getStartDateTime().get(Calendar.DAY_OF_YEAR) == todayDate.get(Calendar.DAY_OF_YEAR)
                && event.getStartDateTime().get(Calendar.YEAR) == todayDate.get(Calendar.YEAR)) {
                result.add(event);
            }
        }
        return result;
    }
}
