﻿using UnityEngine.Networking;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
// Based on https://www.owasp.org/index.php/Certificate_and_Public_Key_Pinning#.Net
class AcceptAllCertificatesSignedWithASpecificKeyPublicKey : CertificateHandler
{

    // Encoded RSAPublicKey
    private static string PUB_KEY = "3082010A0282010100B412745F74F4068F12653496F90F83C24036E839DA8B839351EAAFC1217CF1B777F8C22F5A2D253DCD12BEC9C953BA5B1EFC902613CE17900EEDF79A12F8152794DD667B336F1A44D78D1D6CFD13908352196AD5013B8E2859A5E37C4DC89BCFDCD13F04106914415B9397ECE6F310D1149AFE15C8C2A17D021063B6BE291F9DC583A79DC4FB71B2831526C0AB0115D0EBCE4E2E7E3CE97132351EFF881A822172C095210620B97E208DAF45C503A42E0464D4FB28F8C5E2ABEE28ED57D9570FCF6954DB60A7BDB84773543A942B2A791B83E93D9C569B3E7F0FE57590FD1BEACE87D15B4103827A752F2C13A404870FED1838A1727D84F84AE2A8E78033A2A10203010001";
    private static string PUB_KEY2 =   "3082010A02820101009A350B21F8DF7A673546A299CD97397BEF1B7A5C3D46AEC4201F3F64F2334918F14119378A875610BF7F5803B7CAFC368F0E594F6BC86ED13A3FE822A75412B953B5E28BBAE5AED6D8E26A2871AA6EC5FC8CBC4FFEE8A8C463A817DFF84C875D89FBC07A8DFD639C33A10A0DD8DA86E6D4E15366806F7E2E046110B843F112131D70C12D87871F466C28632C8FEF9DED7FC31685A8FF2594D3E333DC20C67FDD8E42E38CD0768C0D4F6F807C8A0FC4CF555B512E8D7E4D8D93F053D416CBD39BC440DCDBBC0ED475A9D0836BD69FB49EF15FE167061BF3B5185E6CCD8DD7824D88FB7F1F0E70FED9B5A9FA182F5D1CB06C0347D10BF4A3A95814F3440F842C090203010001";
    private static string PUB_KEY3 = "3082010A0282010100FB23EE847E3969703EDD82C715E84C5C78A701A2DC53CBD11B020A46DAC60F3321AD937439837DCAE719E3C27AF62BAD5B292696FE67D68CE7F65D8695B8CDC60EDC10C5AD1AB76FD07566F07DFB50F4BC7E6A49231475ADAB5AC04B4CE090AA818EF6C956DCA731223F09D8AFAF2CCE67265AC40781957CF54426E972A996B7855504B6C9B6C9F97A35A36CE798A7CA688CE5DA9098C86B768C299A0FEF553EED9E4E84EA0A2556BD23C4905CA7C00A8189C8AD70C768D90A4BFE0D35E944FD07161691E996BF9C888EDAE1F6A98267A037B91C3A5EEA8E2DEA273A1CECBCC84F0875A5007CE377A9B5820E43C15529C8BA90B908B259A1FDA5F27C0A84A9710203010001";
    protected override bool ValidateCertificate(byte[] certificateData)
    {

        X509Certificate2 certificate = new X509Certificate2(certificateData);
        string pk = certificate.GetPublicKeyString();
        Debug.Log(pk);
        if (pk.ToLower().Equals(PUB_KEY.ToLower()) 
            || pk.ToLower().Equals(PUB_KEY2.ToLower())
            || pk.ToLower().Equals(PUB_KEY3.ToLower()))
            return true;
        return false;
    }
}