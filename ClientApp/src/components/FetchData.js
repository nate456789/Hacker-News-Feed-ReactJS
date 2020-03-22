import React, {Component} from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;

    constructor(props) {
        super(props);
        this.state = {feedStories: [], loading: true};
    }

    async componentDidMount() {
        await this.fetchFeed();
        this.interval = setInterval(() => {
            console.log('Fetching Data ===>');
            this.fetchFeed();
        }, 60000); // Refresh the feed every minute

    }

    static renderFeedTable(feedStories) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                <tr>
                    <th>Title</th>
                    <th>From</th>
                    <th>Published</th>
                    <th>Author</th>
                    <th>Comments</th>
                </tr>
                </thead>
                <tbody>
                {feedStories.map(story =>
                    <tr key={story.id}>
                        <td><a href={story.url} target="_blank">{story.title}</a></td>
                        <td>{story.baseUrl}</td>
                        <td>{story.published}</td>
                        <td>{story.author}</td>
                        <td>{story.commentCount}</td>
                    </tr>
                )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : FetchData.renderFeedTable(this.state.feedStories);

        return (
            <div>
                <h1 id="tabelLabel">New Links</h1>
                <p>Your source for what is happening around the globe</p>
                {contents}
            </div>
        );
    }

    async fetchFeed() {
        try {
                const apiRoute = "https://api.battinich.com/newsfeed";
            const initValue = {
                mode: 'no-cors'
            };
            const dataRequest = new Request(apiRoute);
            const response = await fetch(dataRequest);
            console.log('Response ==>', response);
            if (response.status === 200) {
                const data = await response.json();
                this.setState({feedStories: data, loading: false});
            }
        } catch (errors) {
            console.log('errors ===>', errors);
        }

    }
}
