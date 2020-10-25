package com.example.realtorhelper;

import java.sql.Time;
import java.util.Calendar;
import java.util.TimeZone;
import java.util.UUID;

public class ResponseRealtorEvent extends RealtorEvent {
    private String uuid;
    private int realtorId;

    public ResponseRealtorEvent(String uuid, int realtorId, long startDateTime, String typeString, long duraction, String comment) {
        super(convertLongToCalendar(startDateTime), convertStringToType(typeString), new Time(duraction), comment);
        this.uuid = uuid;
        this.realtorId = realtorId;

        Calendar startDateTimeCalendar = Calendar.getInstance();
        startDateTimeCalendar.setTimeInMillis(startDateTime);

        RealtorEventType realtorEventType = convertStringToType(typeString);

        Time duractionTime = new Time(duraction);
    }

    public ResponseRealtorEvent(int realtorId, RealtorEvent entity) {
        super(entity.getStartDateTime(), entity.getEventType(), entity.getDuraction(), entity.getComment());
        this.uuid = UUID.randomUUID().toString();
        this.realtorId = realtorId;
    }

    public String getUuid() {
        return uuid;
    }

    public void setUuid(String uuid) {
        this.uuid = uuid;
    }

    public int getRealtorId() {
        return realtorId;
    }

    public void setRealtorId(int realtorId) {
        this.realtorId = realtorId;
    }

    public String getEventTypeString() {
        return convertTypeToString(getEventType());
    }

    private static Calendar convertLongToCalendar(long value)
    {
        Calendar calendar = Calendar.getInstance();
        calendar.setTimeInMillis(value);
        return calendar;
    }

    private static RealtorEventType convertStringToType(String type) {
        switch (type) {
            case "meeting":      return RealtorEventType.clientMeeting;
            case "presentation": return RealtorEventType.show;
            case "call":         return RealtorEventType.plannedCall;
            default:             return RealtorEventType.none;
        }
    }

    private static String convertTypeToString(RealtorEventType type) {
        switch (type) {
            case clientMeeting: return "meeting";
            case show:          return "presentation";
            case plannedCall:   return "call";
            default:            return  "ERROR TYPE";
        }
    }
}
