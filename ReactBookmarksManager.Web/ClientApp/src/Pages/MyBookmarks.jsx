import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import Table from '../Components/Table';

const MyBookmarks = () => {
    const [bookmarks, setBookmarks] = useState([]);

    const loadUser = async () => {
        const { data } = await axios.get('/api/account/getcurrentuserid');
        return data;
    }
    const loadBookmarks = async () => {
        const id = await loadUser();
        const { data } = await axios.get(`/api/bookmarks/getbookmarksforuser?userId=${id}`);
        setBookmarks(data);
    }

    useEffect(() => {
        loadBookmarks();
    },[])

    return (
        <div className='container pt-2'>
            <Link to='/addbookmark' className='btn btn-success'>Add Bookmark</Link>
            <table className='table table-hover table-bordered table-striped mt-4'>
                <thead>
                    <tr>
                        <th>Title</th>
                        <th>Url</th>
                        <th>Edit/Delete</th>
                    </tr>
                </thead>
                <tbody>
                    {bookmarks.map(b => <Table key={b.id} bookmark={b} refreshBookmarks={loadBookmarks} />)}
                </tbody>
            </table>
        </div>
    )
}
export default MyBookmarks;