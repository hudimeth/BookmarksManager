import React, { useState, useEffect } from 'react';
import axios from 'axios'
import TopBookmarksTable from '../Components/TopBookmarksTable';

const Home = () => {
    const [topBookmarks, setTopBookmarks] = useState(null);

    const loadTopBookmarks = async () => {
        const { data } = await axios.get('/api/bookmarks/gettopfivebookmarks');
        setTopBookmarks(data);
    }

    useEffect(() => {
        loadTopBookmarks();
    }, []);

    if (!topBookmarks) {
        return (
            <div className='container pt-5'>
                <div className="text-center">
                    <div className="spinner-border" role="status">
                        <span className="visually-hidden">Loading...</span>
                    </div>
                    <h4>Loading content...</h4>
                </div>
            </div>
        )
    }

    return (
        <div>
            <h1>Welcome to the Bookmarks Manager</h1>
            <h3>Top 5 most bookmarked links:</h3>
            <TopBookmarksTable topBookmarks={topBookmarks} />
        </div>
        )
}
export default Home;