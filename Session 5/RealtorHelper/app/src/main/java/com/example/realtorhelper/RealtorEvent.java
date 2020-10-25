package com.example.realtorhelper;

import androidx.annotation.Nullable;

import java.io.Serializable;
import java.sql.Time;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.time.LocalTime;
import java.util.Calendar;
import java.util.concurrent.locks.ReentrantReadWriteLock;

public class RealtorEvent implements Serializable {
    private Calendar startDateTime;
    private RealtorEventType eventType;
    private Time duraction;
    private String comment;

    public RealtorEvent() {
        startDateTime = Calendar.getInstance();
        eventType = RealtorEventType.clientMeeting;
        duraction = new Time(0, 0, 0);
        comment = "";
    }

    public RealtorEvent(Calendar startDateTime, RealtorEventType eventType, Time duraction, String comment) {
        this.startDateTime = startDateTime;
        this.eventType = eventType;
        this.duraction = duraction;
        this.comment = comment;
    }

    public Calendar getStartDateTime() {
        return startDateTime;
    }

    public void setStartDateTime(Calendar startDateTime) {
        this.startDateTime = startDateTime;
    }

    public RealtorEventType getEventType() {
        return eventType;
    }

    public void setEventType(RealtorEventType eventType) {
        this.eventType = eventType;
    }

    public Time getDuraction() {
        return duraction;
    }

    public void setDuraction(Time duraction) {
        this.duraction = duraction;
    }

    public String getComment() {
        return comment;
    }

    public void setComment(String comment) {
        this.comment = comment;
    }
}
