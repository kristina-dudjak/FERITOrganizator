// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
self.addEventListener('fetch', () => { });


self.addEventListener('push', function (e) {
    var body;
    console.log("event za push");
    body = "Uspjesno dodana biljeska!";


    var options = {
        body: body
    };

    self.registration.showNotification("FERIT Organizator", options);
});