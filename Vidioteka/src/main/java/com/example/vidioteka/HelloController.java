package com.example.vidioteka;

import com.example.vidioteka.entity.ContactInformationEntity;
import javafx.fxml.FXML;
import javafx.scene.control.Label;

public class HelloController {
    @FXML
    private Label welcomeText;

    @FXML
    protected void onHelloButtonClick() {
        welcomeText.setText("qwe");
    }
}
