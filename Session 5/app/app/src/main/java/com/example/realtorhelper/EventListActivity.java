package com.example.realtorhelper;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.ListView;

import com.example.realtorhelper.Adapter.RealtorEventAdapter;
import com.example.realtorhelper.Filter.NullRealtorEventFilter;
import com.example.realtorhelper.Filter.RealtorEventFilter;

import java.util.List;

public class EventListActivity extends BaseActivity {
    private RealtorEventFilter filter;

    public EventListActivity() {
        this(null);
    }

    public EventListActivity(RealtorEventFilter filter) {
        this.filter = filter == null ? new NullRealtorEventFilter() : filter;
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_events_list);
        try {
            RealtorEventFile.getInstance().setFilePath(getFilesDir() + "events.obj");
        }
        catch (ReltorEventIOException e) {
            e.printStackTrace();
        }
        fillList();
        RealtorEventFile.getInstance().addSaveListener(new RealtorEventFile.SaveListener() {
            @Override
            public void onSave() {
                fillList();
            }
        });
    }

    private void fillList() {
        ListView listView = findViewById(R.id.realtorEventList);
        List<RealtorEvent> events = RealtorEventFile.getInstance().getEvents();
        events = filter.use(events);
        listView.setAdapter(new RealtorEventAdapter(events, getLayoutInflater()));
    }


    public void click(View view) {
        Intent intent = new Intent(this, AddEventActivity.class);
        startActivity(intent);
    }

    public void addEvent(View view) {
        Intent intent = new Intent(this, AddEventActivity.class);
        startActivity(intent);
    }
}