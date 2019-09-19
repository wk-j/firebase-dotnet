
import * as firebase from "firebase"
import React from "react"
import ReactDOM from "react-dom"

import 'firebase/auth'
import 'firebase/database'

var firebaseConfig = {
    apiKey: "AIzaSyDXyczRuaZWskx43U-Pamzyw1YaUag79lY",
    authDomain: "github-issue-bot.firebaseapp.com",
    databaseURL: "https://github-issue-bot.firebaseio.com",
    projectId: "github-issue-bot",
    storageBucket: "github-issue-bot.appspot.com",
    messagingSenderId: "699789446244",
    appId: "1:699789446244:web:7b2fc9b70a7c64c4986371"
};

firebase.initializeApp(firebaseConfig);


type State = {
    values: any[]
}

class App extends React.Component<{}, State> {
    constructor(props) {
        super(props)

        this.state = {
            values: []
        }

        firebase.database().ref().child("issues").on("value", (v) => {
            var values = v.val()
            console.log(values)
            this.setState({
                values: Object.values(values)
            })
        });
    }

    render = () =>
        <div>
            <div>Data</div>
            <div>
                {
                    this.state.values.map(x =>
                        <h1>{x.title} - {x.label}</h1>
                    )
                }
            </div>
        </div>
}

var el = document.getElementById("root")
ReactDOM.render(<App />, el)

