package com.example.realtorhelper.Adapter;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Button;
import android.widget.TextView;

import com.example.realtorhelper.R;
import com.example.realtorhelper.RealtorEvent;
import com.example.realtorhelper.RealtorEventFile;
import com.example.realtorhelper.RealtorEventType;
import com.example.realtorhelper.ReltorEventIOException;

import java.text.SimpleDateFormat;
import java.util.List;

public class RealtorEventAdapter extends BaseAdapter {
    private List<RealtorEvent> events;
    private LayoutInflater layoutInflater;

    public RealtorEventAdapter(List<RealtorEvent> events, LayoutInflater layoutInflater) {
        this.events = events;
        this.layoutInflater = layoutInflater;
    }

    @Override
    public int getCount() {
        return events.size();
    }

    @Override
    public Object getItem(int position) {
        return events.get(position);
    }

    @Override
    public long getItemId(int position) {
        return position;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        View view = convertView;
        if(view == null) {
            view = layoutInflater.inflate(R.layout.realtor_event_item, parent, false);
        }

        final RealtorEvent currentEvent = (RealtorEvent)getItem(position);
        TextView startDateTimeView = view.findViewById(R.id.startDateTime);
        TextView typeView = view.findViewById(R.id.eventType);
        TextView duractionTimeView  = view.findViewById(R.id.duraction);
        TextView commentView  = view.findViewById(R.id.comment);

        startDateTimeView.setText("Дата: " + new SimpleDateFormat("dd.MM.yyyy HH:mm")
                .format((currentEvent.getStartDateTime().getTime())));
        duractionTimeView.setText("Продолжительность: "
                + currentEvent.getDuraction().getHours() + " часов "
                + currentEvent.getDuraction().getMinutes() + " минут.");
        typeView.setText(typeToString(currentEvent.getEventType()));
        commentView.setText(currentEvent.getComment());

        final Button removeButton = view.findViewById(R.id.remove);
        removeButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RealtorEventFile.getInstance().remove(currentEvent);
                try {
                    RealtorEventFile.getInstance().saveChanges();
                } catch (ReltorEventIOException e) {
                    e.printStackTrace();
                }
            }
        });

        return view;
    }

    private String typeToString(RealtorEventType type) {
        switch (type) {
            case clientMeeting: return "Встреча с клиентом";
            case show:          return "Показ";
            case plannedCall:   return "Запланированный звонок";
        }
        throw new EnumConstantNotPresentException(RealtorEventType.class, type.toString());
    }
}
