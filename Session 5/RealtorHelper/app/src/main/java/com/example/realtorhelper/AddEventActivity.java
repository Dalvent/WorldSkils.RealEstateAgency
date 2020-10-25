package com.example.realtorhelper;

import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.os.Build;
import android.os.Bundle;
import android.text.method.Touch;
import android.view.MotionEvent;
import android.view.View;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import org.w3c.dom.Text;

import java.io.IOException;
import java.sql.Time;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Calendar;
import java.util.Date;

public class AddEventActivity extends BaseActivity {
    private RealtorEvent event = new RealtorEvent();

    private TextView startDateView;
    private TextView startTimeView;
    private TextView duractionView;
    private DatePickerDialog startDateDialog;
    private TimePickerDialog startTimeDialog;
    private TimePickerDialog duractionDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_event);

        startDateView = findViewById(R.id.startDate);
        startDateView.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                setStartDate(v);
                return true;
            }
        });

        startTimeView = findViewById(R.id.startTime);
        startTimeView.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                setStartTime(v);
                return true;
            }
        });
        duractionView = findViewById(R.id.duractionTime);
        duractionView.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                setDuractionTime(v);
                return true;
            }
        });

        updateStartDate();
        updateStartTime();
        updateDuractionTime();
        initDialogs();
    }

    public void save(View view) {
        setWritedEventType();
        setWritedComment();
        try {
            getRealtorEventRepository().add(event);
        }
        catch (Exception e) {
            Toast.makeText(this, "Can't save object. " + e.getMessage(), Toast.LENGTH_LONG).show();
        }
        this.finish();
    }

    private void setWritedComment() {
        TextView commentView = (TextView)findViewById(R.id.comment);
        event.setComment(commentView.getText().toString());
    }
    private void setWritedEventType() {
        Spinner eventTypeSpinner = (Spinner) findViewById(R.id.eventType);
        event.setEventType(RealtorEventType.values()[(int) eventTypeSpinner.getSelectedItemId() + 1]);
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
    @SuppressLint("SimpleDateFormat")
    public void updateStartDate() {
        startDateView.setText(new SimpleDateFormat("dd.MM.yyyy").
                format(event.getStartDateTime().getTime()));
    }
    @SuppressLint("SimpleDateFormat")
    public void updateStartTime() {
        startTimeView.setText(new SimpleDateFormat("HH:mm").
                format(event.getStartDateTime().getTime()));
    }
    @SuppressLint("SimpleDateFormat")
    public void updateDuractionTime() {
        duractionView.setText(new SimpleDateFormat("HH:mm").
                format(event.getDuraction().getTime()));
    }
    private void initDialogs() {
        DatePickerDialog.OnDateSetListener startDateListener = new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                event.getStartDateTime().set(Calendar.YEAR, year);
                event.getStartDateTime().set(Calendar.MONTH, month);
                event.getStartDateTime().set(Calendar.DAY_OF_MONTH, dayOfMonth);
                updateStartDate();
            }
        };
        startDateDialog = new DatePickerDialog(this, startDateListener,
                event.getStartDateTime().get(Calendar.YEAR),
                event.getStartDateTime().get(Calendar.MONTH),
                event.getStartDateTime().get(Calendar.DAY_OF_MONTH)
        );

        TimePickerDialog.OnTimeSetListener startTimeListener = new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                event.getStartDateTime().set(Calendar.HOUR_OF_DAY, hourOfDay);
                event.getStartDateTime().set(Calendar.MINUTE, minute);
                updateStartTime();
            }
        };
        startTimeDialog = new TimePickerDialog(this, startTimeListener,
                event.getStartDateTime().get(Calendar.HOUR_OF_DAY),
                event.getStartDateTime().get(Calendar.MINUTE), true);

        TimePickerDialog.OnTimeSetListener duractionListener = new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                event.getDuraction().setHours(hourOfDay);
                event.getDuraction().setMinutes(minute);
                updateDuractionTime();
            }
        };
        duractionDialog = new TimePickerDialog(this, duractionListener,
                event.getDuraction().getHours(),
                event.getDuraction().getMinutes(), true);
    }
}