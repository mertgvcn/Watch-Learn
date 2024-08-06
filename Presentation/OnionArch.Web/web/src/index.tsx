import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
//redux
import { Provider } from 'react-redux';
import { store } from './redux/app/store';
//toaster
import { Toaster } from 'react-hot-toast';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
  <Provider store={store}>
    <Toaster />
    <App />
  </Provider>
);