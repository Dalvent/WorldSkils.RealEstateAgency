package com.example.realtorhelper;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;

import com.example.realtorhelper.Adapter.RealtorEventAdapter;
import com.example.realtorhelper.Filter.NullRealtorEventFilter;
import com.example.realtorhelper.Filter.RealtorEventFilter;
import com.example.realtorhelper.Repository.AbstractRepository;

import java.sql.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class EventListActivity extends BaseActivity {
    private RealtorEventFilter filter;

    public EventListActivity() {
        this(null);
    }

    public EventListActivity(RealtorEventFilter filter) {
        super();
        this.filter = filter == null ? new NullRealtorEventFilter() : filter;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_events_list);
    }

    @Override
    protected void onStart() {
        super.onStart();
        fillList();
        getRealtorEventRepository().addChangeListener(new AbstractRepository.ChangeListener() {
            @Override
            public void onChanged() {
                fillList();
            }
        });
    }

    private void fillList() {
        ListView listView = findViewById(R.id.realtorEventList);
        List<RealtorEvent> events = Arrays.asList(getRealtorEventRepository().getAll());
        events = (List<RealtorEvent>) filter.use(events);
        listView.setAdapter(new RealtorEventAdapter(getRealtorEventRepository(), events, getLayoutInflater()));
    }

    public void addEvent(View view) {
        Intent intent = new Intent(this, AddEventActivity.class);
        startActivity(intent);
    }
}