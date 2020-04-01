var main = {
    privateKey: "{PRIVATEKEY}",
    _serverAddress: "{HOST}/fileupload/UploadFiles/",
    getServerAddress: function () {
        return this._serverAddress + this.privateKey;
    }
};