package com.example.realtorhelper.Filter;

import com.example.realtorhelper.RealtorEvent;

import java.util.List;

public class NullRealtorEventFilter implements RealtorEventFilter {

    @Override
    public List<RealtorEvent> use(List<RealtorEvent> list) {
        return list;
    }
}
