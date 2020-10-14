package com.example.realtorhelper;

import com.example.realtorhelper.Filter.TodayReltorEventFilter;

public class TodayEventListActivity extends EventListActivity {
    public TodayEventListActivity() {
        super(new TodayReltorEventFilter());
    }
}
