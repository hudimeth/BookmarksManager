import React from 'react';
import { Route, Routes } from 'react-router';
import { AuthContextComponent } from './AuthContextComponent';
import Layout from './Components/Layout';
import Home from './Pages/Home';
import Login from './Pages/Login';
import Signup from './Pages/Signup';
import Logout from './Logout'
import AddBookmark from './Pages/AddBookmark';
import PrivateRoute from './PrivateRoute';
import MyBookmarks from './Pages/MyBookmarks';

const App = () => {
    return (
        <AuthContextComponent>
            <Layout>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />
                    <Route exact path='/addbookmark' element={
                        <PrivateRoute>
                            <AddBookmark />
                        </PrivateRoute>
                    } />
                    <Route exact path='/mybookmarks' element={
                        <PrivateRoute>
                            <MyBookmarks />
                        </PrivateRoute>
                    } />
                    <Route exact path='/logout' element={
                        <PrivateRoute>
                            <Logout />
                        </PrivateRoute>
                    } />
                </Routes>
            </Layout>
        </AuthContextComponent>
    )
}
export default App;