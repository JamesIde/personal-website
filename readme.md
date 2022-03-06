# Personal Website
[![Netlify Status](https://api.netlify.com/api/v1/badges/9fcda215-bdf5-47b2-a5a6-72c4a546aace/deploy-status)](https://app.netlify.com/sites/trusting-darwin-9db938/deploys)

My website containing personal projects and records in The Archive. You can view the site [here](https://jamesaide.com/).

The front end is created using [Blazor WebAssembly](https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor) and styled with [Bootstrap](https://getbootstrap.com/). I found this the most effective given Bootstrap is baked into .NET projects. Images and texts are hosted on [Contentful](https://www.contentful.com/), which gives me unparalleled freedom and creativity to deserialise into whatever objects I desire, in this case, these are defined in ```portfolio-models/models```. The Contentful CDA is queried by ```portfolio-api``` that is hosted on Azure, and consumed on the client side through ```ContentfulQuery``` service.
This negates having to store any keys in appsettings.json, or use environmental variables to store these keys as the client side cannot access them at a browser level (AFAIK).

## Usage
1. Clone the repository.
2. Modify ```portfolio/wwwroot/appsettings.json``` base URL be the port number the api project is running on. You can find this port number in ```portfolio-api/Properties/launchsettings.json```
3. Create ```appsettings.json``` in ```portfolio-api/www/root``` and add Contentful API Keys. I provided an example appsettings.json file to aid with this. 
4. Modify Models folder to suite your Contentful Models. The model attribute names should match your Contentful Models to help when fetching from the Contentful CDA.

## Resources I Used
- Harmen Hoek's [travel itinerary](https://harmenhoek.com/) for inspiration to create and design The Archive.
- Max Mitchell's [video](https://www.youtube.com/watch?v=m6vxzu95sOI) on building his website with Gatsby and using Contentful. This was my first exposure to the world of content management systems in a well-layed out video with a tangible result at the end. 
- Robert Linde's [blog](https://robertlinde.se/) for Contentful .NET SDK help, alongside the official [documentation](https://www.contentful.com/developers/docs/net/tutorials/using-net-cda-sdk/).

## Future Development
- Fix lighter pack gear list being imported and rendered in razor component. Seems to have trouble loading the script until forced reload. This will be added later.
- Develop my own image lightbox instead of using [Ekko lightbox](http://ashleydw.github.io/lightbox/). Hopefully remove the white border around the images.
- Implement search function based on metadata tags and carousel to accomodate for increasing number of records.
- Write and publish records on non-hiking activities. E.g. Photography, Coding etc. 
- Alter the styling to sooth my perfectionism. 

## Closing Thoughts
I wanted to create a responsive portfolio website using a .NET framework and provide the groundwork for my 'blog' to be built from. Adding new records to The Archive is simple due to the power of SPA frameworks with a headless CMS. The Web API introduces additional complexity and isn't as fast to query and retrieve my Contentful entries as I thought it would be, but remains an excellent alternative to storing all images (hundreds of them) in wwwroot/images.
This project was also a means to test my design skills, and build upon my understanding of Blazor WebAssembly, consuming APIs and sifting through documentation to solve my problems.
