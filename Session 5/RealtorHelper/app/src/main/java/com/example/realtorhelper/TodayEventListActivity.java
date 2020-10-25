package com.example.realtorhelper;

import android.os.Bundle;

import com.example.realtorhelper.Filter.TodayReltorEventFilter;

public class TodayEventListActivity extends EventListActivity {
    public TodayEventListActivity() {
        super(new TodayReltorEventFilter());
    }

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_events_list_today);
    }
}
