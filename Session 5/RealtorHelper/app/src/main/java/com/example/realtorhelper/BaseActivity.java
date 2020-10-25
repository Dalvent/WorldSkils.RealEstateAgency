
package com.example.realtorhelper;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.security.identity.IdentityCredentialException;
import android.view.Menu;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

import com.example.realtorhelper.Repository.AbstractRepository;
import com.example.realtorhelper.Repository.RealtorEventApiRepository;
import com.example.realtorhelper.Repository.RealtorEventFileRepository;
import com.example.realtorhelper.Repository.Repository;

public class BaseActivity extends AppCompatActivity {
    private static AbstractRepository<RealtorEvent> realtorEventRepository;

    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if(realtorEventRepository == null) {
            initRepository();
        }
    }

    private void initRepository() {
        try {
            String fileFullPath = getFilesDir() + "events.obj";
            realtorEventRepository = new RealtorEventApiRepository();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    protected AbstractRepository<RealtorEvent> getRealtorEventRepository() {
        return BaseActivity.realtorEventRepository;
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getMenuInflater().inflate(R.menu.main_menu, menu);
        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        Intent intent = null;
        switch (item.getItemId()) {
            case R.id.createEvent:
                intent = new Intent(this, AddEventActivity.class);
                break;
            case R.id.eventsAll:
                intent = new Intent(this, EventListActivity.class);
                break;
            case R.id.eventsToday:
                intent = new Intent(this, TodayEventListActivity.class);
                break;
            default:
        }
        intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
        startActivity(intent);
        return super.onOptionsItemSelected(item);
    }
}
