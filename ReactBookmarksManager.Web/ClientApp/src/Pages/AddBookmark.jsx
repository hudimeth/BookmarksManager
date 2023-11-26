import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const AddBookmark = () => {
    const [formData, setFormData] = useState({
        title: '',
        url:''
    });
    const navigate = useNavigate();

    const onTextChange = e => {
        const copy = { ...formData };
        copy[e.target.name] = e.target.value;
        setFormData(copy);
    }

    const onFormSubmit = async e => {
        e.preventDefault();
        const { data } = await axios.get('/api/account/getcurrentuser');
        await axios.post('/api/bookmarks/addbookmark', { ...formData, userId: data.id })
        navigate('/mybookmarks');
    }

    return (
        <div className='container pt-5'>
            <div className='row' style={{ display: 'flex', alignItems: 'center' }}>
                <div className='col-md-6 offset-md-3 bg-light p-4 rounded shadow'>
                    <h2>Add Bookmark</h2>
                    <form onSubmit={onFormSubmit}>
                        <input className='form-control mb-3' name='title' placeholder='Title' value={formData.title} onChange={onTextChange} />
                        <input className='form-control mb-3' name='url' placeholder='Url' value={formData.url} onChange={onTextChange} />
                        <button className='btn btn-primary form-control'>Add</button>
                    </form>
                </div>
            </div>
        </div>
        )
}
export default AddBookmark;