package com.example.realtorhelper.Filter;

import com.example.realtorhelper.RealtorEvent;

import java.util.List;

public interface RealtorEventFilter {
    List<RealtorEvent> use(List<RealtorEvent> list);
}
