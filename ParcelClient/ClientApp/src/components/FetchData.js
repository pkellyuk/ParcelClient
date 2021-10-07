import React, { Component } from 'react';

export class FetchData extends Component {
    static displayName = FetchData.name;
    static contents = "";

  constructor(props) {
    super(props);
    this.state = { parcelquotes: [], content: '', weight: "0"};
  }

    handleChange = (e) => {
        this.setState({ weight: e.target.value })
}

    renderParcelQuotesTable(parcelquotes) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Service Name</th>
            <th>Total Price</th>
          </tr>
        </thead>
            <tbody>
                {parcelquotes.quotes.map(parcelquotes =>
                    <tr key={parcelquotes.key}>
                    <td>{parcelquotes.service.name}</td>
                    <td>{parcelquotes.totalPrice}</td>
                </tr>
          )}
        </tbody>
      </table>
    );
  }


  render() {
      const renderParcelQuotes = () => {
          this.populateParcelQuotesData()
      };

    return (
        <div>
            <h1 id="tabelLabel">Parcel Quotes</h1>
            Parcel weight(kg): <input type="text" value={this.state.weight} onChange={this.handleChange} />
            <button type="submit" onClick={() => { renderParcelQuotes() }}>Get Quotes</button>
            {this.state.content}
      </div>
    );
  }

  async populateParcelQuotesData() {
      fetch('/parcel', {
          method: 'POST',
          headers: {
              'Accept': 'application/json',
              'Content-Type': 'application/json'
          },
          body: JSON.stringify({
              parcelWeight: this.state.weight,
              countryFrom: "GBR",
              countryTo: "GBR"
          })
      })
      .then(response => response.json())
          .then(json => {
              this.setState({ parcelquotes: json, content: this.renderParcelQuotesTable(json) });
      });
    }
}
