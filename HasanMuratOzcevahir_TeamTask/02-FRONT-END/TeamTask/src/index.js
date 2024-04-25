import ReactDOM from "react-dom/client";
import "./css/index.scss"
import App from "./App"

import store from "./user/stores/store";
import { Provider } from "react-redux";

ReactDOM.createRoot(
    document.getElementById("root-Team-Task")
).render(

        <Provider store={store}>
            <App />
          
        </Provider>

)

