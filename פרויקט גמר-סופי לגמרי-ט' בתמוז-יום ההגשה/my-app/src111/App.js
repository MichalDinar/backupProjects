import logo from './logo.svg';
import './App.css';
import RecipyList from './component/recipyList';
import { Provider } from 'react-redux';
import store from './redux/store'
import { BrowserRouter, Route, Routes, Switch } from 'react-router-dom';
import Login from './component/login';
import Home from './component/home';
import Register from './component/register';
import UserList from './component/usersList';
import Nav from './component/nav';
import AddRecipy from './component/addRecipy';
import RecipyListPersonal from './component/recipyListPersonal';
import Details from './component/details';
import MyRecipyAdd from './component/myRecipyAdd';
import SignIn from './component/SignIn';

function App() {
  return (<>
    <div className="App">
      <Provider store={store}>
        <BrowserRouter>
          <Routes>
            <Route path="/myNav" element={<Nav />}>
              <Route path="/myNav/myLogin" element={<SignIn />} />
              <Route path="/myNav/myRegister" element={<Register />} />
              <Route path="/myNav/myUsers" element={<UserList />} />
              <Route path="/myNav/myRecipy" element={<RecipyList />} />
              <Route path="/myNav/myAddRecipy" element={<AddRecipy />} />
              <Route path="/myNav/details/name" element={<Details />} />
              <Route path="/myNav/RecipyListPersonal" element={<RecipyListPersonal />} />
              <Route path="/myNav/myRecipyAdd" element={<MyRecipyAdd />} />
            </Route>
            <Route path="/" element={<Home />} />
            <Route path="/myRecipy" element={<RecipyList />} />
          </Routes>
        </BrowserRouter>
      </Provider>
    </div></>
  );
}

export default App;


