package com.example.realtorhelper;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.os.Build;
import android.os.Bundle;
import android.view.View;
import android.widget.DatePicker;

import java.sql.Time;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Date;

public class AddEventActivity extends AppCompatActivity {
    Date startDateTime = new Date();
    Time duraction = new Time(0, 0, 0);

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_event);
    }
    public void setStartDate(View view) {
        new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
            }
        }, startDateTime.getYear(), startDateTime.getMonth(), startDateTime.getDay()).show();
    }

    public void setStartTime(View view) {
    }

    public void setDuractionTime(View view) {
    }
}