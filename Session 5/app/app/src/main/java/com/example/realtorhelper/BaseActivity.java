package com.example.realtorhelper;

import android.app.Activity;
import android.content.Intent;
import android.security.identity.IdentityCredentialException;
import android.view.Menu;
import android.view.MenuItem;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

public class BaseActivity extends AppCompatActivity {
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
