package com.example.realtorhelper;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.util.TimeUtils;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Build;
import android.os.Bundle;
import android.text.format.DateUtils;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.io.File;
import java.sql.Time;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.List;

public class MainActivity extends AppCompatActivity {
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
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
        listView.setAdapter(new RealtorEventAdapter(events, getLayoutInflater()));
    }

    public void click(View view) {
        Intent intent = new Intent(this, AddEventActivity.class);
        startActivity(intent);
    }
}