package com.example.realtorhelper;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.os.Build;
import android.os.Bundle;
import android.text.format.DateUtils;
import android.view.View;
import android.widget.DatePicker;
import android.widget.TextView;
import android.widget.TimePicker;

import org.w3c.dom.Text;

import java.sql.Time;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Calendar;
import java.util.Date;

public class MainActivity extends AppCompatActivity {
    private TextView startDateView;
    private TextView startTimeView;
    private TextView duractionView;


    RealtorEvent realtor = new RealtorEvent();

    private DatePickerDialog startDateDialog;
    private TimePickerDialog startTimeDialog;
    private TimePickerDialog duractionDialog;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_event);

        startDateView = (TextView)findViewById(R.id.startDate);
        startTimeView = (TextView)findViewById(R.id.startTime);
        duractionView = (TextView)findViewById(R.id.duractionTime);

        updateStartDate();
        updateStartTime();
        updateDuractionTime();
        initDialogs();
    }
    public void setStartDate(View view) {
        if(!startDateDialog.isShowing())
            startDateDialog.show();
    }

    public void setStartTime(View view) {
        if(!startTimeDialog.isShowing())
            startTimeDialog.show();
    }

    public void setDuractionTime(View view) {
        if(!duractionDialog.isShowing())
            duractionDialog.show();
    }

    public void updateStartDate() {
        startDateView.setText(DateUtils.formatDateTime(this,
                realtor.getStartDateTime().getTimeInMillis(), DateUtils.FORMAT_SHOW_DATE |
                DateUtils.FORMAT_SHOW_YEAR));
    }

    public void updateStartTime() {
        startTimeView.setText(DateUtils.formatDateTime(this,
                realtor.getStartDateTime().getTimeInMillis(), DateUtils.FORMAT_SHOW_TIME));
    }

    public void updateDuractionTime() {
        duractionView.setText(DateUtils.formatDateTime(this,
                realtor.getDuraction().getTime(), DateUtils.FORMAT_SHOW_TIME));
    }

    private void initDialogs() {
        startDateDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                getStartDateTime().set(Calendar.YEAR, year);
                getStartDateTime().set(Calendar.MONTH, month);
                getStartDateTime().set(Calendar.DAY_OF_MONTH, dayOfMonth);
                updateStartDate();
            }}, startDateTime.get(Calendar.YEAR),
                startDateTime.get(Calendar.MONTH),
                startDateTime.get(Calendar.DAY_OF_MONTH));

        startTimeDialog = new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                startDateTime.set(Calendar.HOUR_OF_DAY, hourOfDay);
                startDateTime.set(Calendar.MINUTE, minute);
                updateStartTime();
            }}, startDateTime.get(Calendar.HOUR_OF_DAY),
                startDateTime.get(Calendar.MINUTE), true);

        duractionDialog = new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                duraction.setHours(hourOfDay);
                duraction.setMinutes(minute);
                updateDuractionTime();;
            }}, duraction.getHours(), duraction.getMinutes(), true);
    }
}