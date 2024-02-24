## Reliable Downloader
### Overview
This project provides a reliable downloader capable of handling various network conditions to ensure smooth content retrieval. It allows users to interactively download content from a specified URL using a command-line interface.

### Usage


#### Initialize Web System Calls: 
The program initiates a WebSystemCalls instance to handle HTTP requests.

#### Specify URL:
 Set the URL from which you want to download content. In the provided example, the Accurx URL ("https://www.accurx.com/") is used.

#### Retrieve HTTP Headers:
GetHeadersAsync method to retrieve HTTP headers for the specified URL. This provides insight into various metadata associated with the resource.

#### Download Content:

DownloadContentAsync method to fetch the entire content from the URL.
Alternatively, utilize the DownloadPartialContentAsync method to download a specified range of bytes if supported by the Content Delivery Network (CDN).
Handle Responses: The downloaded content and any HTTP headers are printed to the console for user inspection
